using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class IncomingGoodsNotScannedItems : IncomingGoodsRequest
    {
        /// <summary>
        /// Scanned NVE or Entered DeliveryNote Number
        /// </summary>
        [DataMember]
        public string inputValue { get; set; }
        /// <summary>
        /// DeliveryNoteNumber of the NVE Scanned
        /// </summary>
        [DataMember]
        public string DeliveryNoteNumber { get; set; }
        /// <summary>
        /// The list that contain the last 4 scanned boxes
        /// </summary>
        [DataMember]
        public NVEList[] UnscannedNVEs { get; set; }
        /// <summary>
        /// Error Messages if any
        /// </summary>
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
    }
}
