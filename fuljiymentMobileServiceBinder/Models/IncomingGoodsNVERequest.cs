using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class IncomingGoodsNVERequest : IncomingGoodsRequest
    {
        [DataMember]
        public string NVEBarcode { get; set; }
    }
}
