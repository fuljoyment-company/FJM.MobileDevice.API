using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class DeliverynoteArticlesObject
    {
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public ProductTransferObject[] Products { get; set; }

        [DataMember]
        public int DeliveryReceiptId { get; set; }

        [DataMember]
        public string DeliveryReceiptNumber { get; set; }

        [DataMember]
        public string ScannedLocationBarcode { get; set; }

        [DataMember]
        public string BinlocationDisplayName { get; set; }

        [DataMember]
        public int UserDbId { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public int[] BranchDbIds { get; set; }

        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public bool StoreExtraArticle { get; set; }
        [DataMember]
        public bool StoreExtraAmount { get; set; }
        [DataMember]
        public bool finishDeliveryReciept { get; set; }
        [DataMember]
        public int totalAmount { get; set; }
        [DataMember]
        public bool limitTotalAmount { get; set; }
        [DataMember]
        public bool RecieveAllProducts { get; set; }
    }
}
