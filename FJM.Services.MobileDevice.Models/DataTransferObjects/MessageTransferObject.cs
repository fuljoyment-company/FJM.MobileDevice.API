using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class MessageTransferObject
    {
        public MessageType Type { get; set; }
        public string Message { get; set; }
    }
    public enum MessageType
    {
        /// <summary>
        /// Error Messages that shows on popup screen
        /// </summary>
        [EnumMember]
        Error,
        /// <summary>
        /// Messages that should open as a dialog and block further scanning attempt
        /// </summary>
        [EnumMember]
        Popup,
        /// <summary>
        /// For new question mark button with live help
        /// </summary>
        [EnumMember]
        HelpContent,
        /// <summary>
        /// Client specific process information (like add correctly sorted)
        /// </summary>
        [EnumMember]
        ProcessDetails,
        /// <summary>
        /// Additional information to be displayed together with the stock location and product information on screen
        /// </summary>
        [EnumMember]
        AdditionalInformation
    }
}
