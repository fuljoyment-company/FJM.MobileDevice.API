using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class IncomingGoodsObject : IncomingGoodsRequest
    {
        /// <summary>
        /// Scanned NVE Number
        /// </summary>
        [DataMember]
        public string NVE { get; set; }
        /// <summary>
        /// DeliveryNoteNumber of the NVE Scanned
        /// </summary>
        [DataMember]
        public string DeliveryNoteNumber { get; set; }
        /// <summary>
        /// Deliveryreceipts DBId
        /// </summary>
        [DataMember]
        public int DeliveryReceiptsID { get; set; }
        /// <summary>
        /// Total Boxes already scanned including the current NVE
        /// </summary>
        [DataMember]
        public int TotalScannedBoxes { get; set; }
        /// <summary>
        /// Total Boxes present in this DeliveryNote
        /// </summary>
        [DataMember]
        public int TotalBoxes { get; set; }
        /// <summary>
        /// Total Article Quantity present in the current scanned NVE
        /// </summary>
        [DataMember]
        public int TotalQuantityInBox { get; set; }
        /// <summary>
        /// Details of Ean and the corresponding quantity in the box
        /// </summary>
        [DataMember]
        public ProductSKU[] Eans { get; set; }
        /// <summary>
        /// Error Messages if any
        /// </summary>
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
        /// <summary>
        /// Flag that says if request is sucessfully processed or not. (true = success, flase = error occured)
        /// </summary>
        [DataMember]
        public bool IsSuccess { get; set; }
        /// <summary>
        /// This Flag says if the scanned NVE contains hanging articles that needs further EAN scans
        /// </summary>
        [DataMember]
        public bool IsHangingArticles { get; set; }
        /// <summary>
        /// If the flag is true then higher amount than present in the Deliverynote can be accepted/saved for a given article
        /// </summary>
        [DataMember]
        public bool AcceptDeliveryQuantityDifference { get; set; }
        /// <summary>
        /// The list that contain the last 4 scanned boxes
        /// </summary>
        [DataMember]
        public NVEList[] LastScannedNVEList { get; set; }
    }
}
