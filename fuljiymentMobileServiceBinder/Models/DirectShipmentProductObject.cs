using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    public class DirectShipmentProductObject
    {
        [DataMember]
        public int ArtDbId { get; set; }
        [DataMember]
        public string Ean { get; set; }
        [DataMember]
        public int QuantityToScan { get; set; }
        [DataMember]
        public int QuantityOfProductsActuallyScanned { get; set; }
        [DataMember]
        public int TotalQuantityToScan { get; set; }
        [DataMember]
        public int WarehouseLogId { get; set; }
        [DataMember]
        public string BinLocationID { get; set; }
        [DataMember]
        public string BinlocationDisplayName { get; set; }
        [DataMember]
        public int StoreID { get; set; }
        [DataMember]
        public bool curActive { get; set; }
        [DataMember]
        public int RawOrderId { get; set; }
        [DataMember]
        public int SequenceNum { get; set; }
    }
}
