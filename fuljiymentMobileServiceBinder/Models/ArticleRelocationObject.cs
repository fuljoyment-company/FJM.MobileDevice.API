using System.Runtime.Serialization;
using static fuljoymentMobileServiceBinder.Models.WarehouseProcessTypesTransferObject;

namespace fuljoymentMobileServiceBinder.Models
{
    public class ArticleRelocationObject
    {
        [DataMember]
        public int UserDbId { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public int[] BranchDbIds { get; set; }

        [DataMember]
        public string FirstBinLocation { get; set; }

        [DataMember]
        public string BinLocation2Relocate { get; set; }

        [DataMember]
        public string ScannedEan { get; set; }

        [DataMember]
        public WarehouseProcessTypes processType { get; set; }

        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public ProductTransferObject[] Products { get; set; }

        [DataMember]
        public int[] associatedClients { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public string BinlocationDisplayName { get; set; }

        [DataMember]
        public int BinTotalAmount { get; set; }

        [DataMember]
        public bool Relocate { get; set; }

        [DataMember]
        public bool Success { get; set; }
    }
}
