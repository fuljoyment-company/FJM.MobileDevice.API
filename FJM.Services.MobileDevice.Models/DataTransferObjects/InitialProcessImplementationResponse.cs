using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static FJM.Services.MobileDevice.Models.DataTransferObjects.WarehouseProcessTypesTransferObject;


namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class InitialProcessImplementationResponse
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public WarehouseProcessTypes processType { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string ProcessName { get; set; }
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
    }
}
