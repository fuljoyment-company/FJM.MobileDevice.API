using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class StockLocationsReturnTransferObject
    {
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
        [DataMember]
        public StockLocationTransferObject[] StockLocations { get; set; }
        [DataMember]
        public int ClientDbId { get; set; }
        [DataMember]
        public int PicklistIdOrZero { get; set; }
        [DataMember]
        public int ProcessCostsIdOrZero { get; set; }
        [DataMember]
        public int ElapsdTimeForProcessSeconds { get; set; }
        [DataMember]
        public bool ScanStockLocationFirst { get; set; }
    }
}
