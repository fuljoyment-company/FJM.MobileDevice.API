using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace fuljoymentMobileServiceBinder.Models
{
    public class UserLoginOrLogoutRequest
    {
        /// <summary>
        /// Only matters for Login.
        /// </summary>
        [DataMember]
        public string Nickname { get; set; }
        /// <summary>
        /// Only matters for Login.
        /// </summary>
        [DataMember]
        public string Password { get; set; }
        /// <summary>
        /// Matters for login, logout and login/logout to working time.
        /// </summary>
        [DataMember]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Matters for login, logout and login/logout to working time.
        /// </summary>
        [DataMember]
        public string Language { get; set; }
        /// <summary>
        /// Matters for logout.
        /// </summary>
        [DataMember]
        public int ProcessCostsIdOrZero { get; set; }
        /// <summary>
        /// Matters for login to working time.
        /// </summary>
        [DataMember]
        public int[] BranchDbIds { get; set; }
        /// <summary>
        /// Matters for logout to working time.
        /// </summary>
        [DataMember]
        public int QuantityOfProductsScannedForProcessCosts { get; set; }
    }
}
