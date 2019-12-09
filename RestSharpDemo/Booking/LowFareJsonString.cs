using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Booking
{
    public class LowFareJsonString
    {
        public string lowFareUrl = "lowfare/retrieve";

        public string lowestFareBody = @"{
                            ""departureStation"": ""MNL"",
                            ""arrivalStation"": ""SIN"",
                            ""beginDate"": ""2019-06-14"",
                            ""endDate"": ""2019-07-14"",
                            ""lowFareRequestType"": ""LowestFare""
                        }";

        public string lowFareCredentials = @"{
                            ""username"": ""carlson@tang.com"",
                            ""password"": ""P@ssw0rd1""
                        }";
    }
}
