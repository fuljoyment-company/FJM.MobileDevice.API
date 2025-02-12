using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class IncomingGoodsNVERequest : IncomingGoodsRequest
    {
        [DataMember]
        public string NVEBarcode { get; set; }
    }
}
