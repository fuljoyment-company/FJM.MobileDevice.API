using FJM.Services.MobileDevice.API.Authentication;
using fuljoymentMobileServiceBinder.Interface;
using fuljoymentMobileServiceBinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FJM.Services.MobileDevice.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApiSettings _apiSettings;
        private IConfiguration _configuration;
        #region Fields
        private readonly IForMobilesService _forMobilesClient;
        #endregion
        public AuthenticationController(IConfiguration configuration, IOptions<ApiSettings> apiSettingsOptions,IForMobilesService forMobilesClient)
        {
            _configuration = configuration;
            _apiSettings = apiSettingsOptions.Value;
            _forMobilesClient = forMobilesClient;
        }
        #region Methods
        [HttpPost("LoginToMobileDevice")]
        public async Task<ActionResult<UserTransferObject>> LoginToMobileDeviceAsync([FromBody] UserLoginOrLogoutRequest request)
        {
            try
            {
                if (HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKeyHeader))
                {
                    string apiKey = apiKeyHeader.FirstOrDefault();
                    var validApiKey = _configuration["ApiKey"]; 

                    if (apiKey == validApiKey)
                    {
                        return await AuthenticateAsync(request);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized,
                            new Response { Status = "Error", Message = "Invalid API Key." });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Response { Status = "Error", Message = "API Key is not present in the header" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new Response { Status = "Error", Message = $"An error occurred: {ex.Message}" });
            }
        }

        private async Task<ActionResult<UserTransferObject>> AuthenticateAsync([FromBody] UserLoginOrLogoutRequest request)
        {
            try
            {
                var response = await _forMobilesClient.LoginToMobileDeviceAsync(request);
                if (response.Messages?.Length > 0)
                    return BadRequest(response.Messages);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
