using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class CheckStocklocationResponse
    {
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public string stocklocation { get; set; }
    }
}
