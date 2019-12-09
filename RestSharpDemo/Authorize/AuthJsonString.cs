using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Authorize
{
    public class AuthJsonString
    {
        //public string _devBaseUrl = "https://gorewards.apps.bcstechnology.com.au/dev/";
        //public string _devBaseUrl = "https://gorewards.apps.bcstechnology.com.au/test";
        public string _devBaseUrl = "http://getgo-cployalty-getgo-gorewards-test.azurewebsites.net/api/v1";

        public string _testBaseUrl = "https://gorewards.apps.bcstechnology.com.au/test/";

        public string _localBaseUrl = "https://localhost:44338/";

        public string getUserUrl(string username)
        {
            string getUserUrl = "users/validate/" + username + "";
            return getUserUrl;
        }

        public string loginUserUrl = "auth/login";

        public string bookingFindFlights = "booking/findflights";

        public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE1NTk1MzIwMjAsImV4cCI6MTU1OTUzNTYyMCwiaWF0IjoxNTU5NTMyMDIwLCJpc3MiOiJkYXZpIn0.iPyYl3H3bdbt0bPmFzQg_2c-XRQECJ6VCkB4ZYiVWI0";

        //public string retrieveProfile = "profiles/me";
        public string retrieveProfile = "Profile";

        //public string registerProfile = "profiles";

        public string registerProfile = "Profile";

        public string _loyaltyRates = "LoyaltyRates/Get";

        public string _skySales = "SkySales";

        public string _refundReverse = "Refund/Reverse";

        public string _getPromoCodeUsage = "SkySales/GetPromoCodeUsage";

        public string _getSkySaleData = "SkySales/GetSkySaleData";

        public string _getMockRates = "LoyaltyRates/api/LoyaltyRates/GetMockRates";

        //public string updateProfile = "profiles/me";

        public string updateProfile = "Profile";

        public string migrateProfile = "profile/migrate";

        public string migrationStatus = "profile/migrationstatus";

        public string validUsername = "tester@yahoo.com";

        public string invalidUsername = "!invaliduser@invalid.com!";

        public string loginCredentials(string username, string password)
        {
            string loginCredentials = @"{
                            ""username"": """ + username + @""",
                            ""password"": """ + password + @"""
                        }";

            return loginCredentials;
        }

        public string lowFareCredentials = @"{
                            ""username"": ""carlson@tang.com"",
                            ""password"": ""P@ssw0rd1""
                        }";

        public string invalidUsernameCombo = @"{
                            ""username"": ""james@bond.com"",
                            ""password"": ""P@ssw0rd1""
                        }";

        public string invalidPasswordCombo = @"{
                            ""username"": ""carlson@tang.com"",
                            ""password"": ""!@#$%%^Invalid""
                        }";

        public string emptyUsernameCombo = @"{
                            ""username"": """",
                            ""password"": ""P@ssw0rd1""
                        }";

        public string emptyPasswordCombo = @"{
                            ""username"": ""tester@yahoo.com"",
                            ""password"": """"
                        }";
    }
}
