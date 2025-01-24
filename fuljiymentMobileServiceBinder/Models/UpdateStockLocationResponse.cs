using System.Runtime.Serialization;

namespace fuljoymentMobileServiceBinder.Models
{
    public class UpdateStockLocationResponse
    {    /// <summary>
         ///  Should return no messags if everything worked, error message otherwise.
         /// </summary>
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

    }
}
