using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha1Provider = new System.Security.Cryptography.SHA1CryptoServiceProvider())
            {
                return Convert.ToBase64String(sha1Provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
