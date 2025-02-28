﻿using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class UpdateStockLocationForBulkStorageRequest
    {
        [DataMember]
        public int BoxId { get; set; }
        [DataMember]
        public int ClientDbId { get; set; }
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public int[] BranchDbIds { get; set; }
        [DataMember]
        public string ScannedLocationBarcode { get; set; }
        [DataMember]
        public string Language { get; set; }
    }
}
