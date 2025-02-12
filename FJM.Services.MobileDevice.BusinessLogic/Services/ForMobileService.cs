using FJM.Services.MobileDevice.Models.DataModels;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FJM.Services.MobileDevice.BusinessLogic.Helpers;
using static FJM.Services.MobileDevice.Models.DataTransferObjects.WarehouseProcessTypesTransferObject;
using FJM.Services.MobileDevice.BusinessLogic.Repositories;

namespace FJM.Services.MobileDevice.BusinessLogic.Services
{
    public class ForMobileService : IForMobileService
    {
        #region Fields
        private readonly IRepositoryManager _repositoryManager;
        #endregion

        #region Constructor
        public ForMobileService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;     
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public async Task<UserTransferObject> LoginToMobileDevice(UserLoginOrLogoutRequest request)
        {
            try
            {
                User user = null;

                if (!string.IsNullOrWhiteSpace(request.Nickname) && !string.IsNullOrWhiteSpace(request.Password))
                {
                    string hashedPassword = PasswordHasher.HashPassword(request.Password);
                    user = await _repositoryManager._users.GetUserBynameAndPasswordAsync(request.Nickname,hashedPassword, null); // Generic Repository in action
                }
                else if (!string.IsNullOrWhiteSpace(request.EmployeeCode))
                {
                    user = await _repositoryManager._users.GetUserBynameAndPasswordAsync(null,null,request.EmployeeCode);
                }

                if (user == null)
                {
                    return UserTransferFactory.CreateErrorResponse("Invalid credentials");
                }

                return UserTransferFactory.CreateSuccessResponse(user);
            }
            catch (Exception ex)
            {
                return UserTransferFactory.CreateErrorResponse($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<InitialProcessImplementationResponse> DecideInitialProcessImplementation(InitialProcessImplementationRequest request)
        {

            try
            {
                // Validate ScannedBarcode
                if (string.IsNullOrWhiteSpace(request.ScannedBarcode))
                {
                    throw new ArgumentException("ScannedBarcode cannot be null or empty.");
                }

                // Process the Scanned Barcode
                string scannedCode = request.ScannedBarcode;
                string processType = scannedCode.Substring(3, 3);
                string clientCode = scannedCode.Substring(8, 3);
                int clientId = Convert.ToInt32(clientCode);

                // Fetch Client from repository
                Client client = await _repositoryManager._clients.GetClientByAccessIdAsync(clientId);

                if (client == null)
                {
                    return new InitialProcessImplementationResponse
                    {
                        Messages = new[] {
                            new MessageTransferObject
                            {
                                Type = MessageType.Error,
                                Message = request.Language.ToUpper().Equals("EN") ? "Client not found!" : "Client nicht gefunden."
                            }
                        }
                    };
                }

                var response = new InitialProcessImplementationResponse
                {
                    ClientId = client.id
                };

                // Logic for processType handling
                switch (processType)
                {
                    case "100":
                        response.processType = WarehouseProcessTypes.DelRec1st2ndScan;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan/enter the delivery receipt number" : "Lieferscheinnummer scannen/eingeben";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "NewGoods 1+2.Scan" : "NEU 1+2.Scan";
                        break;
                    case "101":
                        response.processType = WarehouseProcessTypes.ArticlesInWagon;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a WagonId" : "WagonID scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "NUR-Storein" : "NUR-Einlagerung";
                        break;
                    case "102":
                        response.processType = WarehouseProcessTypes.DelRec2ndScanZBin;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "NewGoods Z-Lager" : "NEU Z-Lager";
                        break;
                    case "103":
                        response.processType = WarehouseProcessTypes.ReturnedGoodsStore;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "NewGoods Z-Lager" : "NEU Z-Lager";
                        break;
                    case "111":
                        response.processType = WarehouseProcessTypes.IncomingGoodsNVEScan;
                        response.message = request.Language.ToUpper() == "EN" ? "scan a NVE" : "NVE scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "IncomingGoods-NVE Scan" : "Wareneingang-NVE Scan";
                        break;
                    case "112":
                        response.processType = WarehouseProcessTypes.IncomingNVEHangingGoods;
                        response.message = request.Language.ToUpper() == "EN" ? "scan a NVE" : "NVE scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "IncomingGoods-Hanging articles" : "Wareneingang-Hängeware";
                        break;
                    case "113":
                        response.processType = WarehouseProcessTypes.IncomingGoodsNoDeliveryNote;
                        response.message = request.Language.ToUpper() == "EN" ? "Enter a Delivery note number" : "Lieferscheinnummer eingeben";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "IncomingGoods-No deliveryNote" : "Wareneingang-Ohne LS";
                        break;
                    case "199":
                        response.processType = WarehouseProcessTypes.StoreMagicArticle;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Store an Article" : "Artikel Einfach Einlag.";
                        break;
                    case "200":
                        response.processType = WarehouseProcessTypes.BinlocationStockCheck;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Binlocation Amount" : "LO-Bestand";
                        break;
                    case "201":
                        response.processType = WarehouseProcessTypes.WarehouseInventory;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Inventory" : "Inventur";
                        break;
                    case "202":
                        response.processType = WarehouseProcessTypes.InventoryControlScan;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Inventory - Control" : "Inventur - Kontroll Scann";
                        break;
                    case "300":
                        response.processType = WarehouseProcessTypes.ArticleRelocation;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Article Relocation" : "Artikel umlagerung";
                        break;
                    case "301":
                        response.processType = WarehouseProcessTypes.WarehouseRelocation;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Warehouse Relocation" : "Lagerumzug";
                        break;
                    case "302":
                        response.processType = WarehouseProcessTypes.KartonRelocation;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a Binlocation" : "Lagerort scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Karton Relocation" : "Karton umlagerung";
                        break;
                    case "401":
                        response.processType = WarehouseProcessTypes.DirectStoreShipments;
                        response.message = request.Language.ToUpper() == "EN" ? "Scan a WagonId/picklistId" : "WagonID/PicklistID scannen";
                        response.ProcessName = request.Language.ToUpper() == "EN" ? "Direct Store Shipments" : "Direktverteilung auf Filiale";
                        break;
                    default:
                        response.Messages = new[] {
                            new MessageTransferObject
                            {
                                Type = MessageType.Error,
                                Message = request.Language.ToUpper().Equals("EN") ? "Process not yet implemented!" : "unbekannter Prozess"
                            }
                        };
                        break;
                }

                return response;
            }
            catch (Exception ex)
            {
                return new InitialProcessImplementationResponse
                {
                };
            }
        }

        public async Task<IncomingGoodsObject> IncomingNVEScanAsync(IncomingGoodsNVERequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IncomingGoodsObject> IncomingNVEHangingProductsScanAsync(IncomingGoodsObject request)
        {
            throw new NotImplementedException();
        }

        public async Task<IncomingGoodsObject> IncomingGoodsUnscannedItemsAsync(IncomingGoodsNotScannedItems request)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
