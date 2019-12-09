using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpDemo;
using RestSharpDemo.Authorize;
using RestSharpDemo.Booking;
using System;

namespace APITest
{
    public class Booking : Common
    {
        BookingJsonString bookingJsonString = new BookingJsonString();
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();
        public BookingFindFlights findFlightsContent, addFlightsContent, clearBookingContent, bookingSummaryContent, updatePassengerContent;
        public IRestResponse bookingSummaryResponse;
        private static Random random = new Random();
        public static int randomString = random.Next(100000);
        public static string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
        public string fareSellKey = string.Empty;
        public string journeySellKey = string.Empty;
        public string JWTNoFlights = string.Empty;
        public string JWT = string.Empty;

        public void Init(string username, string password)
        {
            var restUrl = restApi.SetUrl(_devBaseUrl, loginUserUrl);
            var restRequest = restApi.CreatePostRequest(loginCredentials(username, password));
            var response = restApi.GetResponse(restUrl, restRequest);
            UserData content = restApi.GetContent<UserData>(response);

            JWT = content.responseData.token;
        }

        public void FindFlights(string departureStation, string arrivalStation, string beginDate, string endDate)
        {
            var response = CreatePostRequestWithTokenBody(_devBaseUrl, bookingJsonString.findFlightsUrl, JWT, bookingJsonString.FindFlightsBody(departureStation, arrivalStation, beginDate, endDate));

            findFlightsContent = restApi.GetContent<BookingFindFlights>(response);

            if (findFlightsContent.responseDescription == "Success.")
            {
                fareSellKey = findFlightsContent.responseData.flightJourneys[0].flightSegments[0].fareSellKey;
                journeySellKey = findFlightsContent.responseData.flightJourneys[0].journeySellKey;
            }
        }

        public void AddFlights(string fareSellKey, string journeySellKey)
        {
            var response = CreatePostRequestWithTokenBody(_devBaseUrl, bookingJsonString.addFlightsUrl, JWT, bookingJsonString.AddFlightsBody(fareSellKey, journeySellKey));

            addFlightsContent = restApi.GetContent<BookingFindFlights>(response);
        }

        public void UpdatePassenger(string firstName, string lastName)
        {
            var response = CreatePostRequestWithTokenBody(_devBaseUrl, bookingJsonString.updatePassengerUrl, JWT, bookingJsonString.UpdatePassengerBody(firstName, lastName));

            updatePassengerContent = restApi.GetContent<BookingFindFlights>(response);
        }

        public void BookingSummary(string JWT)
        {
            var response = CreateGetRequestWithToken(_devBaseUrl, bookingJsonString.bookingSummaryUrl, JWT);

            bookingSummaryContent = restApi.GetContent<BookingFindFlights>(response);
            bookingSummaryResponse = response;
        }

        public void ClearBooking()
        {
            var response = CreatePostRequestWithToken(_devBaseUrl, bookingJsonString.clearBookingUrl, JWT);

            clearBookingContent = restApi.GetContent<BookingFindFlights>(response);
        }

        public void EndToEndBooking() //Find Flights + Add Flights + Booking Summary + Clear Booking
        {
            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = "HKG"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            //Find all flights available today
            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual(findFlightsContent.responseData.flightJourneys[0].departureStation, flightJourney.departureStation);

            //Add a flight from the result in FindFlights
            AddFlights(fareSellKey, journeySellKey);
            Assert.IsTrue(addFlightsContent.responseData.bookingUpdateResponse.success);

            //Get Booking Summary
            BookingSummary(JWT);
            Assert.AreEqual(bookingSummaryContent.responseData.journeys[0].departureStation, flightJourney.departureStation);

            //Clear all bookings of a specific user
            ClearBooking();
            Assert.IsTrue(clearBookingContent.responseData.success);
        }

        public void FindFlightsFromPastDate()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = "HKG"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual("No fares found", findFlightsContent.responseDescription);
        }

        public void FindFlightsWithPastEndDate()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = "HKG"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = dateToday,
                endDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            if (!findFlightsContent.responseDescription.Contains("Arrival date may not be before Departure date."))
                Assert.Fail("AvailabilityRequest.EndDate:MinMaxDateTimeAttribute");
        }

        public void FindFlightsWithInvalidDepartureStation()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "XXX",
                arrivalStation = "HKG"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual(findFlightsContent.responseDescription, "Station does not exist.  StationCode = " + flightJourney.departureStation + "");
        }

        public void FindFlightsWithEmptyDepartureStation()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "",
                arrivalStation = "HKG"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual("The DepartureStation field is required.", findFlightsContent.error.detail);
        }

        public void FindFlightsWithInvalidArrivalStation()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = "XXX"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual(findFlightsContent.responseDescription, "Station does not exist.  StationCode = " + flightJourney.arrivalStation + "");
        }

        public void FindFlightsWithEmptyArrivalStation()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = ""
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual("The ArrivalStation field is required.", findFlightsContent.error.detail);
        }

        public void FindFlightsWithSameDestinationAndArrivalStation()
        {

            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = "MNL"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            Assert.AreEqual("No fares found", findFlightsContent.responseDescription);
        }

        public void AddFlightsUsingPastDate()
        {
            var flightSegment = new FlightSegment
            {
                fareSellKey = "0~V~~5J~VRP~6001~~0~1~~X"
            };

            var flightJourney = new FlightJourney
            {
                journeySellKey = "5J~ 803~ ~~MNL~07/01/2019 20:30~SIN~07/02/2019 00:05~~"
            };

            //Add Flights - Act
            AddFlights(flightSegment.fareSellKey, flightJourney.journeySellKey);

            if (!addFlightsContent.error.detail.Contains("Agent is not authorized to sell a flight this close to departure time"))
                Assert.Fail("Selling a flight near Departure time is not allowed");
        }

        public void UpdatePassengerWithFlights()
        {
            var flightJourney = new FlightJourney
            {
                departureStation = "MNL",
                arrivalStation = "HKG"
            };

            var findFlightsRequest = new FindFlightsRequest
            {
                beginDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"),
                endDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd")
            };

            var updatePassenger = new UpdatePassenger
            {
                firstName = "First Name " + randomString.ToString(),
                lastName = "Last Name " + randomString.ToString()
            };

            //Clear Booking - Act
            ClearBooking();
            //Find Flights - Act
            FindFlights(flightJourney.departureStation, flightJourney.arrivalStation, findFlightsRequest.beginDate, findFlightsRequest.endDate);
            //Add Flights - Act
            AddFlights(fareSellKey, journeySellKey);
            //Update Passenger - Act
            UpdatePassenger(updatePassenger.firstName, updatePassenger.lastName);

            //Assert
            BookingSummary(JWT);
            Assert.IsTrue(updatePassengerContent.responseData.success);
            Assert.AreEqual(bookingSummaryContent.responseData.journeys[0].departureStation, flightJourney.departureStation);
            Assert.AreEqual(bookingSummaryContent.responseData.journeys[0].departureStation, flightJourney.arrivalStation);
        }

        public void UpdatePassengerWithoutFlights()
        {
            var updatePassenger = new UpdatePassenger
            {
                firstName = "First Name " + randomString.ToString(),
                lastName = "Last Name " + randomString.ToString()
            };

            //Clear Booking - Act
            ClearBooking();
            //Update Passenger - Act
            UpdatePassenger(updatePassenger.firstName, updatePassenger.lastName);
            //Assert
            Assert.AreEqual("No passenger booking data found, add flights first before updating passenger information", updatePassengerContent.error.detail);
        }

        public void LoginWithoutBookedFlights()
        {
            var restUrl = restApi.SetUrl(_devBaseUrl, loginUserUrl);
            var restRequest = restApi.CreatePostRequest(bookingJsonString.noFlightsCredentials);
            var response = restApi.GetResponse(restUrl, restRequest);
            UserData content = restApi.GetContent<UserData>(response);

            JWTNoFlights = content.responseData.token;
        }


    }
}
