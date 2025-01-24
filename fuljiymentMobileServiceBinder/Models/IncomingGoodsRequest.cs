using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static fuljoymentMobileServiceBinder.Models.WarehouseProcessTypesTransferObject;

namespace fuljoymentMobileServiceBinder.Models
{
    public class IncomingGoodsRequest
    {
        [DataMember]
        public int UserDbId { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public int[] BranchDbIds { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public WarehouseProcessTypes processType { get; set; }
    }
}
