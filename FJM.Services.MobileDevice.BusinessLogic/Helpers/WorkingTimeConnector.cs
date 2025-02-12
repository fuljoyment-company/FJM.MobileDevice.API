using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJM.Services.MobileDevice.BusinessLogic.Helpers
{
    public class WorkingTimeConnector
    {
        const string CONNECTION_STRING = "data source=dx292-pd.fuljoyment.com;initial catalog=timeRecording;user id=app_timerec;password=5L7TgbL1eDttxzKZ28A3;TrustServerCertificate=True;";

        public static bool GetUserIsLoggedIn(string identCardNumber)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 [beginning], [end] FROM WorkforceTimeRegistration WHERE workforceID = @workforceId ORDER BY ID DESC;", con);
                cmd.Parameters.AddWithValue("@workforceId", GetEmployeeIdForIdentCardNumber(con, identCardNumber));
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    // 24/09/2018 We have this problem today.
                    if (!reader.HasRows)
                        return false;

                    // Handle the uncommon possibility that the login date might be null.
                    if (reader.GetValue(0) == DBNull.Value) return false;

                    object loginTime = reader.GetDateTime(0);
                    object logoutTime = reader.GetValue(1);

                    if (Convert.ToDateTime(loginTime).Date == DateTime.Today && logoutTime == DBNull.Value)
                        return true;
                    else
                        return false;
                }
            }
        }
        static int GetEmployeeIdForIdentCardNumber(SqlConnection con, string identCardNumber)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM WorkforceClan WHERE cardNr = @identCardNumber;", con);
            cmd.Parameters.AddWithValue("@identCardNumber", identCardNumber);

            int employeeId = -1;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                if (!reader.HasRows)
                    return -1;

                employeeId = reader.GetInt32(0);
            }

            return employeeId;
        }
    }
}
