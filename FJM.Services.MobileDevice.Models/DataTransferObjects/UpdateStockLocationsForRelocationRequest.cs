using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class UpdateStockLocationsForRelocationRequest
    {
        [DataMember]
        public string ScannedSecondStockLocationBarcode { get; set; }
        [DataMember]
        public int RelocatedQuantity { get; set; }
        [DataMember]
        public int FirstStockLocationDbId { get; set; }
        [DataMember]
        public int ProductDbId { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public int[] BranchDbIds { get; set; }
    }
}
