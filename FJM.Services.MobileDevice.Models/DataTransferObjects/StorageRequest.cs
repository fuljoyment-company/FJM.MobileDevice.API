using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class StorageRequest
    {
        /// <summary>
        /// Can be EAN code or WarehouseActionLog.id
        /// </summary>
        [DataMember]
        public string ScannedBarcode { get; set; }
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public int[] BranchDbIds { get; set; }
        [DataMember]
        public int AreaInWarehouseCode { get; set; }
        [DataMember]
        public int TimesScannedToFindFittingStorage { get; set; }
        [DataMember]
        public string Language { get; set; }
    }
}
