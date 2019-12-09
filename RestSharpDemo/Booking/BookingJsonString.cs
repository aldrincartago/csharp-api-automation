using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Booking
{
    public class BookingJsonString
    {
        public string bookingSummaryUrl = "booking/summary";

        public string findFlightsUrl = "flights/availability";

        public string addFlightsUrl = "booking/flights";

        public string updatePassengerUrl = "booking/passengers";

        public string clearBookingUrl = "booking/clear";

        public string findFlightsCredentials = @"{
                            ""username"": ""jamesjones@yahoo.com"",
                            ""password"": ""test123""
                        }";

        public string noFlightsCredentials = @"{
                            ""username"": ""tester@yahoo.com"",
                            ""password"": ""test123""
                        }";

        public string FindFlightsBody(string departureStation, string arrivalStation, string beginDate, string endDate)
        {
            string findFlightsBody = @"{
                            ""departureStation"": """ + departureStation + @""",
                            ""arrivalStation"": """ + arrivalStation + @""",
                            ""beginDate"": """ + beginDate + @""",
                            ""endDate"": """ + endDate + @""",
                            ""currencyCode"": ""PHP"",
                            ""paxTypes"": [
  	                            ""ADT""
                              ]
                        }";
            return findFlightsBody;

        }

        public string AddFlightsBody(string fareSellKey, string journeySellKey)
        {
            string addFlightsBody = @"{
              ""journeyData"": [
		            {
			            ""fareSellKey"": """ + fareSellKey + @""",
			            ""journeySellKey"": """ + journeySellKey + @"""
		            }
                              ],
                              ""paxTypes"": [
  	                            ""ADT""
                              ]
                        }";
            return addFlightsBody;
        }

        public string UpdatePassengerBody(string firstName, string lastName)
        {
            string updatePassengerBody = @"{
                        ""country"": ""PH"",
                        ""passengers"": [
                        {
                            ""firstName"": """ + firstName + @""",
                            ""middleName"": """",
                            ""lastName"": """ + lastName + @""",
                            ""title"": ""Mr"",
                            ""dateOfBirth"": ""1992-10-23"",
                            ""paxType"": ""ADT"",
                            ""gender"": ""M"",
                            ""passengerNumber"": 0,
                            ""ipscExemp"": true
                        }
                        ] 
                    }";
            return updatePassengerBody;
        }
    }
}
