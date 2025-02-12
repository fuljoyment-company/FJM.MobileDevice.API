using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class WarehouseProcessTypesTransferObject
    {
        public enum WarehouseProcessTypes
        {
            [EnumMember]
            DelRec1st2ndScan,//DeliveryReceipt 1st and 2nd Scan
            [EnumMember]
            ReturnedGoodsStore,//ReturnedGoodsStorein  
            [EnumMember]
            ArticleRelocation,
            [EnumMember]
            BinlocationStockCheck,//Binlocation StockCheck
            [EnumMember]
            Null,
            [EnumMember]
            WarehouseRelocation,
            //[EnumMember]
            //DelRec2ndScan,//DeliveryReceipt 2nd Scan
            [EnumMember]
            DelRec2ndScanZBin,//DeliveryReceipt 2nd Scan for Z-Bins
            [EnumMember]
            ArticlesInWagon,//DelRec2ndScan, ReturnedGoodsStore, RelocationforZBins - all these process are combined as one. (15/01/2020 ReturnedGoodsStore is not yet implemented)
            [EnumMember]
            StoreMagicArticle,//This process is used by Ingo to simply store an article that is physically in Warehouse without any processing reference to it. Both Binlocation & ArtilceAmount is increased with a log type(6) Manualchange
            [EnumMember]
            WarehouseInventory,
            [EnumMember]
            InventoryControlScan,
            //In this Process a box/Karton can be relocated from one Z-bin to another Z-bin.
            [EnumMember]
            KartonRelocation,
            [EnumMember]
            //Shipment of the Articles while storein. Direktverteilung auf Filiale 
            DirectStoreShipments,
            [EnumMember]
            IncomingGoodsNVEScan,
            [EnumMember]
            IncomingNVEHangingGoods,
            [EnumMember]
            IncomingGoodsNoDeliveryNote
        }
    }
}
