using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    public class ProductAttributeTransferObject
    {
        [DataMember]
        public ProductAttributeType Type { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public bool Display { get; set; }
    }
    public enum ProductAttributeType
    {
        [EnumMember]
        ColorCode,
        [EnumMember]
        ColorName,
        [EnumMember]
        Size,
        [EnumMember]
        PackagingUnit,
        [EnumMember]
        Brand
    }
}
