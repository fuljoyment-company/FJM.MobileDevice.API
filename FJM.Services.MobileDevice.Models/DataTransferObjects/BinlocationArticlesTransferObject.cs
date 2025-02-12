using System.Runtime.Serialization;
using static FJM.Services.MobileDevice.Models.DataTransferObjects.WarehouseProcessTypesTransferObject;


namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class BinlocationArticlesTransferObject
    {
        [DataMember]
        public int UserDbId { get; set; }

        [DataMember]
        public string Language { get; set; }

        [DataMember]
        public int[] BranchDbIds { get; set; }

        [DataMember]
        public string ScannedBinLocation { get; set; }

        [DataMember]
        public string ScannedEan { get; set; }

        [DataMember]
        public int[] associatedClients { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public WarehouseProcessTypes processType { get; set; }

        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

        [DataMember]
        public ProductTransferObject[] Products { get; set; }

        [DataMember]
        public bool success { get; set; }

        [DataMember]
        public bool isMultipleBin { get; set; }

        [DataMember]
        public string BinlocationDisplayName { get; set; }

        [DataMember]
        public int wagonID { get; set; }

        [DataMember]
        public int TotalAmount { get; set; }

        [DataMember]
        public bool displayTotalAmount { get; set; }

        [DataMember]
        public bool isComplete { get; set; }

        [DataMember]
        public bool binreserved { get; set; }

        [DataMember]
        public string binreservedEan { get; set; }

        [DataMember]
        public bool isZBin { get; set; }
    }
}
