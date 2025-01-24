using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    public class StockLocationsForProductResponse : StockLocationsReturnTransferObject
    {
        [DataMember]
        public int FirstStockLocationDbId { get; set; }
        [DataMember]
        public int ProductDbId { get; set; }
        /// <summary>
        /// To display how many products should be available for relocation, sometimes they want to know how many products are stored in this stock location.
        /// </summary>
        [DataMember]
        public int QuantityInFirstStockLocation { get; set; }
    }
}
