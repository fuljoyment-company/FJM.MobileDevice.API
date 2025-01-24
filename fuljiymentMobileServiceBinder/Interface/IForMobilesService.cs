using fuljoymentMobileServiceBinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Interface
{
    public interface IForMobilesService
    {
        Task<UserTransferObject> LoginToMobileDeviceAsync(UserLoginOrLogoutRequest request);
        Task<InitialProcessImplementationResponse> DecideInitialProcessImplementationAsync(InitialProcessImplementationRequest request);
        Task<IncomingGoodsObject> IncomingNVEScanAsync(IncomingGoodsNVERequest request);
        Task<IncomingGoodsObject> IncomingNVEHangingProductsScanAsync(IncomingGoodsObject request);
        Task<IncomingGoodsNotScannedItems> IncomingGoodsUnscannedItemsAsync(IncomingGoodsNotScannedItems request);
    }
}
