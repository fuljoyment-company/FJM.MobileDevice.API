using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    /// <summary>
    /// Bulk storage works in a way that the device scans a box and is supplied with the product content in this box.
    /// The box is later put into a stock location and serves as stock location.
    /// </summary>
    public class BulkStorageResponse
    {
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
        [DataMember]
        public int BoxId { get; set; }
        [DataMember]
        public int ClientDbId { get; set; }
      
    }
}
