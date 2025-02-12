using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.Models.DataTransferObjects
{
    public class UserTransferObject
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public string EmployeeCode { get; set; }
        [DataMember]
        public bool LoggedInToWorkingTime { get; set; }
        [DataMember]
        public int UserDbId { get; set; }
        [DataMember]
        public MessageTransferObject[] Messages { get; set; }
    }
}
