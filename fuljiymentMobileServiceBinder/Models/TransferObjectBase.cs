using System.Runtime.Serialization;
using static fuljoymentMobileServiceBinder.Models.WarehouseProcessTypesTransferObject;

namespace fuljoymentMobileServiceBinder.Models
{
    public class TransferObjectBase
    {
        [DataMember]
        public int UserDbId { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public int[] BranchDbIds { get; set; }

        [DataMember]
        public int[] associatedClients { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public WarehouseProcessTypes processType { get; set; }
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

    }
}
