using System.Runtime.Serialization;
using static fuljoymentMobileServiceBinder.Models.WarehouseProcessTypesTransferObject;

namespace fuljoymentMobileServiceBinder.Models
{
    public class GetDeliverynoteArticlesRequest
    {
        [DataMember]
        public int UserDbId { get; set; }

        [DataMember]
        public string ScannedBarcode { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public int[] BranchDbIds { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public string ScannedBinlocation { get; set; }

        [DataMember]
        public WarehouseProcessTypes processType { get; set; }
    }
}
