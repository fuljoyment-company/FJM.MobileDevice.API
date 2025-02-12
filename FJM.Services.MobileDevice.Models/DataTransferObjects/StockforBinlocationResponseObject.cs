using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class StockforBinlocationResponseObject
    {
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public ProductTransferObject[] Products { get; set; }

        [DataMember]
        public string stocklocation { get; set; }

        [DataMember]
        public int TotalAmount { get; set; }

        [DataMember]
        public string ScannedBinLocation { get; set; }

        [DataMember]
        public bool canBeMultiple { get; set; }

        [DataMember]
        public bool isZbin { get; set; }
    }
}
