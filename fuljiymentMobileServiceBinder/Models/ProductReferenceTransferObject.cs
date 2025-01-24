using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{  
    public class ProductReferenceTransferObject
    {
        [DataMember]
        public ProductReferenceType Type { get; set; }
        [DataMember]
        public int DbId { get; set; }
        /// <summary>
        /// Takes care that we don't need to supply references to the Web-service that are not relevant, e.g. the Quantity field should be lowered by the references updates in DB and
        /// not supplied to the Web-service update method when quantity is below one.
        /// </summary>
        [DataMember]
        public int QuantityInRelatedTableToUpdate { get; set; }
    }   
    public enum ProductReferenceType
    {
        [EnumMember]
        OrderLine,
        [EnumMember]
        ExchangeLine,
        [EnumMember]
        WarehouseLogLine,
        [EnumMember]
        SingleSwapLine,
        [EnumMember]
        SwapLine,
        [EnumMember]
        PickingCompleteOrderId,
        [EnumMember]
        PickingCompleteAndFulfillOrderId,
        //12.10.2021 This type is used when we do first scan for picklist that is created for OrderRawData.
        [EnumMember]
        PicklistWarehouseLogLine
    }
}
