using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class UpdateStockLocationRequest : StockLocationTransferObject
    {
        [DataMember]
        public int QuantityChange { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public int ClientDbId { get; set; }
        [DataMember]
        public int PicklistIdOrZero { get; set; }
    }
}
