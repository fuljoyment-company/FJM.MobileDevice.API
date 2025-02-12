using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class InitialProcessImplementationRequest
    {
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public string ScannedBarcode { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public int[] BranchDbIds { get; set; }
    }
}
