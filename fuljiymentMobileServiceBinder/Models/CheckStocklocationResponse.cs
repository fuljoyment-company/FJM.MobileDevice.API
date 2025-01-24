using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    public class CheckStocklocationResponse
    {
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public string stocklocation { get; set; }
    }
}
