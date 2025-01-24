using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class PersistCompletionRequest
    {
        [DataMember]
        public StockLocationTransferObject[] AllProcessedStockLocations { get; set; }
        [DataMember]
        public int ProcessCostsDbId { get; set; }
        [DataMember]
        public string Langauge { get; set; }
        [DataMember]
        public int ClientDbId { get; set; }
        [DataMember]
        public int UserDbId { get; set; }

    }
}
