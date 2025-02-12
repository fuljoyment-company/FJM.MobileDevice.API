using FJM.Services.MobileDevice.BusinessLogic.Services;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FJM.Services.MobileDevice.API.Controllers.DecideInitialProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecideInitialProcessController : ControllerBase
    {
        #region Fields
        private readonly IForMobileService _forMobilesClient;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DecideInitialProcessController"/> class.
        /// </summary>
        /// <param name="forMobilesClient">Service responsible for handling initial process decisions.</param>
        public DecideInitialProcessController(IForMobileService forMobilesClient)
        {
            _forMobilesClient = forMobilesClient;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Processes the barcode and determines the initial process implementation.
        /// </summary>
        /// <param name="request">The request containing barcode and related data.</param>
        /// <returns>
        /// - <see cref="OkObjectResult"/> (200) with <see cref="InitialProcessImplementationResponse"/> if the process is successful.
        /// - <see cref="BadRequestObjectResult"/> (400) if the request is invalid or contains error messages.
        /// - <see cref="StatusCodeResult"/> (500) if an unexpected server error occurs.
        /// </returns>
        [HttpPost("ProcessBarcode")]
        public async Task<ActionResult<InitialProcessImplementationResponse>> DecideInitialProcessImplementationAsync([FromBody] InitialProcessImplementationRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new { Message = "Request body cannot be null" });
                }

                var response = await _forMobilesClient.DecideInitialProcessImplementation(request);

                if (response == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An unexpected error occurred" });
                }

                if (response.Messages != null && response.Messages.Any())
                {
                    return BadRequest(response);
                }

                return Ok(response);
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }
        #endregion
    }
}
