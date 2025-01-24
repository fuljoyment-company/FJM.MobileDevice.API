using fuljoymentMobileServiceBinder.Interface;
using fuljoymentMobileServiceBinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FJM.Services.MobileDevice.API.Controllers.DecideInitialProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecideInitialProcessController : ControllerBase
    {
        #region Fields
        private readonly IForMobilesService _forMobilesClient;
        #endregion
        #region Constructor
        public DecideInitialProcessController(IForMobilesService forMobilesClient)
        {
            _forMobilesClient = forMobilesClient;
        }
        #endregion
        #region Methods
        [HttpPost("ProcessBarcode")]
        public async Task<ActionResult<InitialProcessImplementationResponse>> DecideInitialProcessImplementationAsync([FromBody] InitialProcessImplementationRequest request)
        {
            try
            {
                var response = await _forMobilesClient.DecideInitialProcessImplementationAsync(request); 
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
