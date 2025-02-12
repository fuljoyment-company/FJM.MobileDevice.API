using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class IncomingGoodsNoDNRequest : IncomingGoodsRequest
    {
        [DataMember]
        public string DeliveryNoteNumber { get; set; }
    }
}
