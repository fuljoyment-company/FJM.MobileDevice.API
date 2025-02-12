using FJM.Services.MobileDevice.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Services
{
    public interface IForMobileService
    {
        Task<UserTransferObject> LoginToMobileDevice(UserLoginOrLogoutRequest request);
        Task<InitialProcessImplementationResponse> DecideInitialProcessImplementation(InitialProcessImplementationRequest request);
        Task<IncomingGoodsObject> IncomingNVEScanAsync(IncomingGoodsNVERequest request);
        Task<IncomingGoodsObject> IncomingNVEHangingProductsScanAsync(IncomingGoodsObject request);
        Task<IncomingGoodsObject> IncomingGoodsUnscannedItemsAsync(IncomingGoodsNotScannedItems request);

    }
}
