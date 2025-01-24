using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    public class StoreDeliverynoteResponse
    {
        [DataMember]
        public bool isComplete { get; set; }

        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public ProductTransferObject[] Products { get; set; }

        [DataMember]
        public int totalAmount { get; set; }
    }
}
