using fuljoymentMobileServiceBinder.Interface;
using fuljoymentMobileServiceBinder.Models;
using SSLfuljoymentMobileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Services
{
    public class SslfuljoymentMobileServiceAdapter : IForMobilesService
    {
        #region Fields
        private readonly ForMobilesClient _serviceClient;
        #endregion

        #region Constructor
        public SslfuljoymentMobileServiceAdapter(ForMobilesClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Models.UserTransferObject> LoginToMobileDeviceAsync(Models.UserLoginOrLogoutRequest request)
        {
            try
            {
                var serviceRequest = new SSLfuljoymentMobileService.UserLoginOrLogoutRequest
                {
                    BranchDbIds = request.BranchDbIds,
                    Nickname = request.Nickname,
                    Password = request.Password,
                    EmployeeCode = request.EmployeeCode
                };

                // Call the service
                var serviceResponse = await _serviceClient.LoginToMobileDeviceAsync(serviceRequest);
                return new Models.UserTransferObject
                {
                    UserDbId = serviceResponse.UserDbId,
                    Name = serviceResponse.Name,
                    Nickname = serviceResponse.Nickname,
                    EmployeeCode = serviceResponse.EmployeeCode,
                    LoggedInToWorkingTime = serviceResponse.LoggedInToWorkingTime,
                    Messages = serviceResponse.Messages.Select(m => new Models.MessageTransferObject
                    {
                        Type = (Models.MessageType)m.Type,
                        Message = m.Message
                    }).ToArray()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Models.InitialProcessImplementationResponse> DecideInitialProcessImplementationAsync(Models.InitialProcessImplementationRequest request)
        {
            try
            {
                var serviceRequest = new SSLfuljoymentMobileService.InitialProcessImplementationRequest
                {
                    BranchDbIds = request.BranchDbIds,
                    Language = request.Language,
                    UserDbId = request.UserDbId,
                    ScannedBarcode = request.ScannedBarcode
                };

                // Call the service
                var serviceResponse = await _serviceClient.DecideInitialProcessImplementationAsync(serviceRequest);
                return new Models.InitialProcessImplementationResponse
                {
                    ClientId = serviceResponse.ClientId,
                    Messages = serviceResponse.Messages.Select(m => new Models.MessageTransferObject
                    {
                        Type = (Models.MessageType)m.Type,
                        Message = m.Message
                    }).ToArray(),
                    ProcessName = serviceResponse.ProcessName,
                    processType = (WarehouseProcessTypesTransferObject.WarehouseProcessTypes)serviceResponse.processType,
                    message = serviceResponse.message

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        public async Task<Models.IncomingGoodsObject> IncomingNVEScanAsync(Models.IncomingGoodsNVERequest request)
        {
            try
            {
                var serviceRequest = new SSLfuljoymentMobileService.IncomingGoodsNVERequest
                {
                    BranchDbIds = request.BranchDbIds,
                    UserDbId = request.UserDbId,
                    Language = request.Language,
                    ClientId = request.ClientId,
                    processType = WarehouseProcessTypes.IncomingGoodsNVEScan,
                    NVEBarcode = request.NVEBarcode
                };
                var serviceResponse = await _serviceClient.IncomingNVEScanAsync(serviceRequest);
                return new Models.IncomingGoodsObject
                {
                    UserDbId = serviceResponse.UserDbId,
                    Language = serviceResponse.Language,
                    ClientId = serviceResponse.ClientId,
                    BranchDbIds = serviceResponse.BranchDbIds,
                    NVE = serviceResponse.NVE,
                    DeliveryNoteNumber = serviceResponse.DeliveryNoteNumber,
                    DeliveryReceiptsID = serviceResponse.DeliveryReceiptsID,
                    TotalScannedBoxes = serviceResponse.TotalScannedBoxes,
                    TotalBoxes = serviceResponse.TotalBoxes,
                    TotalQuantityInBox = serviceResponse.TotalQuantityInBox,
                    Eans = serviceResponse.Eans.Select(e => new Models.ProductSKU
                    {
                        EAN = e.EAN,
                        Art_X_Del_ID = e.Art_X_Del_ID,
                        TotalQuantity = e.TotalQuantity,
                        TotalSavedQuantity = e.TotalSavedQuantity,
                        CurrentScanQuantity = e.CurrentScanQuantity
                    }).ToArray(),
                    Messages = serviceResponse.Messages.Select(m => new Models.MessageTransferObject
                    {
                        Type = (Models.MessageType)m.Type,
                        Message = m.Message
                    }).ToArray(),
                    IsSuccess = serviceResponse.IsSuccess
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Models.IncomingGoodsObject> IncomingNVEHangingProductsScanAsync(Models.IncomingGoodsObject request)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.IncomingGoodsNotScannedItems> IncomingGoodsUnscannedItemsAsync(Models.IncomingGoodsNotScannedItems request)
        {
            try
            {
                var serviceRequest = new SSLfuljoymentMobileService.IncomingGoodsNotScannedItems
                {
                    BranchDbIds = request.BranchDbIds,
                    Language = request.Language,
                    UserDbId = request.UserDbId,
                    processType = WarehouseProcessTypes.IncomingGoodsNVEScan,
                    DeliveryNoteNumber = request.DeliveryNoteNumber,
                    inputValue = request.inputValue
                };
                var serviceResponse = _serviceClient.IncomingGoodsUnscannedItemsAsync(serviceRequest);

                // Ensure UnscannedNVEs is not null before mapping
                var unscannedNVEs = serviceResponse.Result.UnscannedNVEs != null
                    ? serviceResponse.Result.UnscannedNVEs.Select(nve => new Models.NVEList
                    {
                        BoxNVE = nve.BoxNVE,
                        BoxNumber = nve.BoxNumber
                    }).ToArray()
                    : Array.Empty<Models.NVEList>();

                return new Models.IncomingGoodsNotScannedItems
                {
                    BranchDbIds = serviceRequest.BranchDbIds,
                    Language = serviceRequest.Language,
                    UserDbId = serviceRequest.UserDbId,
                    DeliveryNoteNumber = serviceRequest.DeliveryNoteNumber,
                    UnscannedNVEs = unscannedNVEs
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
