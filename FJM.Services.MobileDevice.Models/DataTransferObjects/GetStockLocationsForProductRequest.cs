using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class GetStockLocationsForProductRequest
    {
        [DataMember]
        public string ScannedStockLocationBarcode { get; set; }
        /// <summary>
        /// For mixed stock locations, it is necessary to know which product to relocate
        /// </summary>
        [DataMember]
        public string ScannedProductEanCode { get; set; }
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public int[] BranchDbIds { get; set; }
    }
}
