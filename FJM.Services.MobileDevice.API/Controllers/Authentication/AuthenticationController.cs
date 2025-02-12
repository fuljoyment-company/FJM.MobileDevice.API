using FJM.Services.MobileDevice.API.Authentication;
using FJM.Services.MobileDevice.BusinessLogic.Services;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FJM.Services.MobileDevice.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {        
        #region Fields
        private readonly ApiSettings _apiSettings;
        private IConfiguration _configuration;
        private readonly IForMobileService _mobileService;
        private UserTransferObject _loggedInUser;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration settings.</param>
        /// <param name="mobileService">Service handling authentication for mobile devices.</param>
        /// <param name="apiSettingsOptions">Options containing API settings.</param>
        public AuthenticationController(IConfiguration configuration, IForMobileService mobileService, IOptions<ApiSettings> apiSettingsOptions)
        {
            _configuration = configuration;
            _apiSettings = apiSettingsOptions.Value;
            _mobileService = mobileService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Authenticates a user attempting to log in to a mobile device.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>
        /// Returns an HTTP response containing:
        /// - <see cref="UserTransferObject"/> if authentication is successful.
        /// - A <see cref="BadRequestResult"/> if the request data is invalid.
        /// - An <see cref="UnauthorizedResult"/> if authentication fails due to invalid credentials.
        /// - A <see cref="StatusCodeResult"/> (500) if an internal server error occurs.
        /// </returns>
        [HttpPost("LoginToMobileDevice")]
        public async Task<ActionResult<UserTransferObject>> LoginToMobileDeviceAsync([FromBody] UserLoginOrLogoutRequest request)
        {
            try
            {
                
                if (request == null)
                    return BadRequest(new { message = "Invalid request data." });

                var response = await _mobileService.LoginToMobileDevice(request);

                if (response == null || response.Messages == null)
                    return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });

                if (response.Messages.Any(m => m.Message == "Invalid credentials" || m.Message.StartsWith("An error occurred")))
                {
                    return Unauthorized(new { message = response.Messages });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "An internal server error occurred. Please try again later." });
            }

        }
        #endregion
    }
}
