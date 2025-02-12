using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class DirectStoreShipmentsTransferObject : TransferObjectBase
    {
        [DataMember]
        public DirectShipmentProductObject[] Products { get; set; }

        [DataMember]
        public string ScannedBinlocation { get; set; }
        [DataMember]
        public string ScannedBox { get; set; }
        [DataMember]
        public bool Success { get; set; }
        /// <summary>
        /// used for the algorithm to calculate the nearest Bins to store article.
        /// </summary>
        [DataMember]
        public KeyValuePairObject[] freeBins { get; set; }

        [DataMember]
        public int MaxBinrangeForRefill { get; set; }

        //If this flag is set then the values are stored after every single Ean scan
        [DataMember]
        public bool saveAfterArticleScan { get; set; }

        [DataMember]
        public bool useSortingAlgorithm { get; set; }

        [DataMember]
        public bool mustScanEan { get; set; }

        [DataMember]
        public int currentBinSequence { get; set; }
    }

    public class KeyValuePairObject
    {
        [DataMember]
        public int key { get; set; }

        [DataMember]
        public string value { get; set; }
    }
}
