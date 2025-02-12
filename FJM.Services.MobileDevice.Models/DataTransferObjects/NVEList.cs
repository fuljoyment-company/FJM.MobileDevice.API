using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class NVEList
    {
        [DataMember]
        public string BoxNVE { get; set; }

        [DataMember]
        public string BoxNumber { get; set; }
    }
}
