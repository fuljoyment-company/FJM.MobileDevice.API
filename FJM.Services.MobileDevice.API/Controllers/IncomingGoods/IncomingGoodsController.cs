using FJM.Services.MobileDevice.BusinessLogic.Services;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
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
        private readonly IForMobileService _forMobilesClient;
        #endregion

        #region Constructor
        public IncomingGoodsController(IForMobileService forMobilesClient)
        {
            _forMobilesClient = forMobilesClient;
        }
        #endregion

        #region Methods

        [HttpPost("NVEScan")]
        public async Task<ActionResult<IncomingGoodsObject>> IncomingNVEScanAsync([FromBody] IncomingGoodsNVERequest request)
        {
            return null;
        }
                
        [HttpPost("Hanging articles")]
        public async Task<IActionResult> IncomingNVEHangingProductsScanAsync([FromBody] IncomingGoodsObject request)
        {            
            return null;
        }

        [HttpPost("UnscannedItems")]
        public async Task<IActionResult> IncomingGoodsUnscannedItemsAsync([FromBody] IncomingGoodsNotScannedItems request)
        {
            return null;
        }
        #endregion
    }
}
