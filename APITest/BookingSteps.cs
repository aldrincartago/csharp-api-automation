using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace APITest
{
    [Binding]
    public class BookingSteps : Booking
    {
        Common common = new Common();
        string futureBeginDate = DateTime.Now.AddDays(+5).ToString("yyyy-MM-dd");
        string futureEndDate = DateTime.Now.AddDays(+5).ToString("yyyy-MM-dd");

        [BeforeScenario("booking")]
        public void Initialize()
        {
            Init("frankcastle@tester.com", "test123");
        }

        [Given(@"I find a flight from (.*) to (.*) using today's date")]
        public void GivenIFindAFlightToday(string departureStation, string arrivalStation)
        {
            var beginDate = DateTime.Now.ToString("yyyy-MM-dd");
            var endDate = DateTime.Now.ToString("yyyy-MM-dd");

            FindFlights(departureStation, arrivalStation, beginDate, endDate);
        }

        [Given(@"I find a flight from (.*) to (.*) using past date")]
        public void GivenIFindAPastFlight(string departureStation, string arrivalStation)
        {
            var beginDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            var endDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            FindFlights(departureStation, arrivalStation, beginDate, endDate);
        }

        [Given(@"I find a flight from (.*) to (.*) using future date")]
        public void GivenIFindAFutureFlight(string departureStation, string arrivalStation)
        {
            FindFlights(departureStation, arrivalStation, futureBeginDate, futureEndDate);
        }

        [Given(@"I login as a user without any booked flights")]
        public void GivenILoginWithoutBookedFlights()
        {
            LoginWithoutBookedFlights();
        }

        [Given(@"I clear all booked flights of a user")]
        public void GivenIClearAllBookedFlights()
        {
            ClearBooking();
        }

        [Given(@"I add a flight from (.*) to (.*) using future date")]
        public void GivenIAddAFlightUsingFutureDate(string departureStation, string arrivalStation)
        {
            FindFlights(departureStation, arrivalStation, futureBeginDate, futureEndDate);
            AddFlights(fareSellKey, journeySellKey);
        }

        [When(@"I get the Booking Summary")]
        public void WhenIGetTheBookingSummary()
        {
            BookingSummary(JWTNoFlights);
        }

        [When(@"I book the earliest flight")]
        public void WhenIBookEarliestFlight()
        {
            AddFlights(fareSellKey, journeySellKey);
        }

        [When(@"I update a passsenger's name with (.*) and (.*)")]
        public void WhenIUpdatePassengerNameWithFirstAndLastName(string firstName, string lastName)
        {
            UpdatePassenger(firstName, lastName);
        }

        [Then(@"I should see (.*) in the Update response body")]
        public void IShouldSeeTextInTheUpdateResponseBody(string responseText)
        {
            Assert.AreEqual(updatePassengerContent.responseDescription, responseText);
        }

        [Then(@"I should be able to see (.*) in the Get Booking response")]
        public void ThenIShouldBeAbleToSeeTextInGetBooking(int responseCode)
        {
            int numericStatusCode = common.GetStatusCode(bookingSummaryResponse);
            Assert.AreEqual(responseCode, numericStatusCode);
        }

        [Then(@"I should be able to see my (.*) to (.*) Booking Summary")]
        public void ThenIShouldBeAbleToSeeMyBookingSummary(string departureStation, string arrivalStation)
        {
            BookingSummary(JWT);
            int numericStatusCode = common.GetStatusCode(bookingSummaryResponse);

            Assert.AreEqual(200, numericStatusCode);
            Assert.AreEqual(departureStation, bookingSummaryContent.responseData.journeys[0].departureStation);
            Assert.AreEqual(arrivalStation, bookingSummaryContent.responseData.journeys[0].arrivalStation);
        }

        [Then(@"I should be able to see (.*) in the response description")]
        public void ThenIShouldSeeTextInTheResponseDescription(string responseDescription)
        {
            Assert.AreEqual(responseDescription, findFlightsContent.responseDescription);
        }

        [Then(@"I should be able to see (.*) in the error detail")]
        public void ThenIShouldSeeTextInTheErrorDetail(string errorDetail)
        {
            if (!findFlightsContent.error.detail.Contains(errorDetail))
                Assert.Fail(errorDetail + " text is not found in the response body");

        }
    }
}
