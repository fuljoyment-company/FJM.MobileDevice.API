using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    /// <summary>
    /// 07/05/2018 Add for different EAN codes for different package contents, like pce, lots and bags
    /// You can scan either EAN for it's respective quantity and measurement
    /// </summary>   
    public class UnitOfMeasurementTransferObject
    {
        [DataMember]
        public string Ean { get; set; }
        [DataMember]
        public int QuantityToScan { get; set; }
        [DataMember]
        public int QuantityOfProductsActuallyScanned { get; set; }
        [DataMember]
        public UnitOfMeasurementType UnitOfMeasurement { get; set; }
    }

    // Need to change string unit to Enumeration. There are 3 possible logics so far. The product can be one piece, it can be a package of multiple pieces of the same SKU
    // and it can be a package of multiple different pieces
    
    public enum UnitOfMeasurementType
    {
        [EnumMember]
        Pce,
        [EnumMember]
        PackageUnit,
        [EnumMember]
        BundleOfDifferentProducts
    }
}
