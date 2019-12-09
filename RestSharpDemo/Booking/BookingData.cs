using System;
using System.Collections.Generic;

namespace RestSharpDemo
{
    public class Charge
    {
        public double amount { get; set; }
        public string pointPrice { get; set; }
        public string chargeCode { get; set; }
        public string currencyCode { get; set; }
        public int chargeType { get; set; }
    }

    public class PaxFare
    {
        public int paxType { get; set; }
        public string totalPointsPrice { get; set; }
        public string totalFarePrice { get; set; }
        public string totalTaxes { get; set; }
        public List<Charge> charges { get; set; }
    }

    public class FlightFare
    {
        public string taxPrice { get; set; }
        public string farePrice { get; set; }
        public string currencyCode { get; set; }
        public string totalPointsPrice { get; set; }
        public List<object> discounts { get; set; }
        public string basePointsPrice { get; set; }
        public string multiplier { get; set; }
        public string fareForeignPrice { get; set; }
        public string fareForeignCurrencyCode { get; set; }
        public List<PaxFare> paxFares { get; set; }
    }

    public class FlightSegment
    {
        public string carrierCode { get; set; }
        public string flightNumber { get; set; }
        public string departureStation { get; set; }
        public DateTime departureDate { get; set; }
        public string arrivalStation { get; set; }
        public DateTime arrivalDate { get; set; }
        public string flightDuration { get; set; }
        public string arrivalTerminalInfo { get; set; }
        public string departureTerminalInfo { get; set; }
        public string fareClassOfService { get; set; }
        public string cabinClass { get; set; }
        public string fareBasisCode { get; set; }
        public string segmentSellKey { get; set; }
        public string fareSellKey { get; set; }
        public FlightFare flightFare { get; set; }
        public List<object> passengerSsrs { get; set; }
        public List<object> passengerSeats { get; set; }
        public bool international { get; set; }
    }

    public class FlightFare2
    {
        public string taxPrice { get; set; }
        public string farePrice { get; set; }
        public string currencyCode { get; set; }
        public string totalPointsPrice { get; set; }
        public List<object> discounts { get; set; }
        public string basePointsPrice { get; set; }
        public string multiplier { get; set; }
        public string fareForeignPrice { get; set; }
        public string fareForeignCurrencyCode { get; set; }
    }

    public class FlightJourney
    {
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public string departureTime { get; set; }
        public DateTime departureDate { get; set; }
        public string departureTerminalInfo { get; set; }
        public string arrivalTime { get; set; }
        public DateTime arrivalDate { get; set; }
        public string arrivalTerminalInfo { get; set; }
        public string totalFlightDuration { get; set; }
        public string flightType { get; set; }
        public List<FlightSegment> flightSegments { get; set; }
        public FlightFare2 flightFare { get; set; }
        public string journeySellKey { get; set; }
    }

    public class Passenger
    {
        public string customerNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int paxType { get; set; }
        public string gender { get; set; }
        public int passengerNumber { get; set; }
        public List<object> paxFees { get; set; }
        public bool ipscExemp { get; set; }
    }

    public class BookingUpdateResponse
    {
        public bool success { get; set; }
    }

    public class FindFlights
    {
        public List<FlightJourney> flightJourneys { get; set; }
        public List<FlightJourney> journeys { get; set; }
        public List<Passenger> passengers { get; set; }
        public string currencyCode { get; set; }
        public string recordLocator { get; set; }
        public string numericRecordLocator { get; set; }
        public string balanceDue { get; set; }
        public int lastPaymentStatus { get; set; }
        public List<object> payments { get; set; }
        public string bookingStatus { get; set; }
        public int channel { get; set; }
        public BookingUpdateResponse bookingUpdateResponse { get; set; }
        public bool success { get; set; }
    }

    public class FindFlightsError
    {
        public int code { get; set; }
        public string detail { get; set; }
    }

    public class BookingFindFlights
    {
        public int responseCode { get; set; }
        public string responseDescription { get; set; }
        public FindFlights responseData { get; set; }
        public FindFlightsError error { get; set; }
    }

    public class FindFlightsRequest
    {
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public string currencyCode { get; set; }
        public string paxTypes { get; set; }
    }

    public class UpdatePassenger
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string dateOfBirth { get; set; }
        public string passengerNumber { get; set; }
    }
}
