using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class StockLocationTransferObject
    {
        [DataMember]
        public int LocationDbId { get; set; }
        // Overall stock for all products.
        [DataMember]
        public int Stock { get; set; }
        [DataMember]
        public string FullLocationCode { get; set; }

        // Specific stock locatione related coordinates.
        // The name of the warehouse area or zone some stock locations belong to.
        /// <summary>
        /// Primary column in table BinLocationStorageAreaTypes.
        /// </summary>
        [DataMember]
        public int AreaInWarehouseCode { get; set; }
        /// <summary>
        /// Type column in table BinLocationStorageAreaTypes.
        /// </summary>
        [DataMember]
        public AreaType AreaInWarehouseType { get; set; }
        /// <summary>
        /// Jana had the input to scan only a second time for new storages.
        /// </summary>
        [DataMember]
        public bool ForceSecondStockLocationScan { get; set; }
        /// <summary>
        /// Name column in table BinLocationStrageAreaTypes.
        /// Type 1 = Fast, Type 2 = Medium
        /// </summary>
        [DataMember]
        public string AreaInWarehouseName { get; set; }
        /// <summary>
        /// Single stock location location parameter
        /// </summary>
        [DataMember]
        public int WarehouseCode { get; set; }
        [DataMember]
        public int ShelfNumber { get; set; }
        [DataMember]
        public int ColumnNumber { get; set; }
        [DataMember]
        public string RowCode { get; set; }
        [DataMember]
        public string Size { get; set; }
        //28.05.2020 ProcessCosts are saved from now in ProcessTime DbTable.
        [DataMember]
        public int ProcessTimeID { get; set; }


        // Allow hints for emplyees that explain our processes etc.
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
        [DataMember]
        public ProductTransferObject[] Products { get; set; }
    }

    [DataContract(Namespace = "http://www.fuljoyment.com/forMobiles")]
    public enum AreaType
    {
        [EnumMember]
        FastTrack,
        [EnumMember]
        Default,
        [EnumMember]
        BGradeProducts,
        [EnumMember]
        DefectGradeProducts
    }
}
