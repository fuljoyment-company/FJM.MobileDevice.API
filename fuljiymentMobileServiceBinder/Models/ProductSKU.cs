using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class ProductSKU
    {
        /// <summary>
        /// EAN Code of the Article
        /// </summary>
        [DataMember]
        public string EAN { get; set; }
        /// <summary>
        /// DB ID of Art_XDel
        /// </summary>
        [DataMember]
        public int Art_X_Del_ID { get; set; }
        /// <summary>
        /// total quantity for this EAN
        /// </summary>
        [DataMember]
        public int TotalQuantity { get; set; }
        /// <summary>
        /// total quantity that is already saved in the Database
        /// </summary>
        [DataMember]
        public int TotalSavedQuantity { get; set; }
        /// <summary>
        /// The quantity that has been scanned currently
        /// </summary>
        [DataMember]
        public int CurrentScanQuantity { get; set; }
    }
}
