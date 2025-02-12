using FJM.Services.MobileDevice.Models.DataModels;
using FJM.Services.MobileDevice.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Helpers
{
    public class UserTransferFactory
    {
        public static UserTransferObject CreateSuccessResponse(User user)
        {
            return new UserTransferObject
            {
                Name = user.firstName +" "+user.lastName,
                Nickname = user.nickname,
                EmployeeCode = user.identCardNumber,
                LoggedInToWorkingTime = WorkingTimeConnector.GetUserIsLoggedIn(user.identCardNumber),
                UserDbId = user.id,
                Messages = new[] { new MessageTransferObject { Message = "Login successful" } }
            };
        }

        public static UserTransferObject CreateErrorResponse(string message)
        {
            return new UserTransferObject
            {
                Messages = new[] { new MessageTransferObject { Message = message } }
            };
        }
    }
}
