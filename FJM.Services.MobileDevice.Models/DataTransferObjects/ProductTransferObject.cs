using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class ProductTransferObject
    {
        // To find product in database easily for updates.
        [DataMember]
        public int DbId { get; set; }
        [DataMember]
        public string ImageLocation { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Stock { get; set; }
        [DataMember]
        public int MixedStockLocationId { get; set; }
        [DataMember]
        public bool ToScanOnlyOnceIsOkay { get; set; }
        [DataMember]
        // Unit of measurement knows about how many products to scan
        public UnitOfMeasurementTransferObject[] UnitOfMeasurements { get; set; }

        // As for stock locations, allow here for hints as well
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
        [DataMember]
        public ProductAttributeTransferObject[] Attributes { get; set; }
        [DataMember]
        public ProductReferenceTransferObject[] References { get; set; }
    }
}
