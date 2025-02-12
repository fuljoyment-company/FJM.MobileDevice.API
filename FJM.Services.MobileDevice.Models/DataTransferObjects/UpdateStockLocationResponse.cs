using System.Runtime.Serialization;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class UpdateStockLocationResponse
    {    /// <summary>
         ///  Should return no messags if everything worked, error message otherwise.
         /// </summary>
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }

    }
}
