using fuljoymentMobileServiceBinder.Interface;
using fuljoymentMobileServiceBinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FJM.Services.MobileDevice.API.Controllers.IncomingGoods
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingGoodsController : ControllerBase
    {
        #region Fields
        private readonly IForMobilesService _forMobilesClient;
        #endregion
        #region Constructor
        public IncomingGoodsController(IForMobilesService forMobilesClient)
        {
            _forMobilesClient = forMobilesClient;
        }
        #endregion

        #region Methods

        [HttpPost("NVEScan")]
        public async Task<ActionResult<IncomingGoodsObject>> IncomingNVEScanAsync([FromBody] IncomingGoodsNVERequest request)
        {
            try
            {
                var response = await _forMobilesClient.IncomingNVEScanAsync(request); 
                if (response.Messages?.Length > 0)
                    return BadRequest(response.Messages);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "A service error occurred.", details = ex.Message });
            }   
        }
                
        [HttpPost("Hanging articles")]
        public async Task<IActionResult> IncomingNVEHangingProductsScanAsync([FromBody] IncomingGoodsObject request)
        {
            var result = await _forMobilesClient.IncomingNVEHangingProductsScanAsync(request);
            return Ok(result);
        }

        [HttpPost("UnscannedItems")]
        public async Task<IActionResult> IncomingGoodsUnscannedItemsAsync([FromBody] IncomingGoodsNotScannedItems request)
        {
            try
            {
                var response = await _forMobilesClient.IncomingGoodsUnscannedItemsAsync(request); 
                if (response.Messages?.Length > 0)
                    return BadRequest(response.Messages);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
            }
        }
        #endregion
    }
}
