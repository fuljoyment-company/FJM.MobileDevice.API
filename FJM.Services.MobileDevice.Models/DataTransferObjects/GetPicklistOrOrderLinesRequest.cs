using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class GetPicklistOrOrderLinesRequest
    {
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public string LabelOrInvoiceBarcode { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public int[] BranchDbIds { get; set; }
    }
}
