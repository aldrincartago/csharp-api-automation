using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using TechTalk.SpecFlow;

namespace APITest
{
    [Binding]
    public class LoyaltyRatesSteps : LoyaltyRates
    {
        Common common = new Common();

        [Given(@"I view Loyalty Rates of flight from (.*) to (.*)")]
        public void ViewLoyaltyRatesOfTextFromText(string _destination, string _arrival)
        {
            GetLoyaltyRates(_destination, _arrival, "01/01/2020", "01/08/2020");
        }

        [Given(@"I get all Loyalty Rates Extension from (.*) to (.*)")]
        public void IGetLoyaltyRatesExt(string _destination, string _arrival)
        {
            GetLoyaltyRatesExt(_destination, _arrival);
        }

        [Given(@"I get all valid Mock Rates")]
        public void IGetAllValidMockRates()
        {
            GetMockRates();
        }

        [Then(@"I should be able to see (.*) in the Get Loyalty Rates response")]
        public void ThenIShouldBeAbleToSeeTextInGetBooking(int responseCode)
        {
            int numericStatusCode = common.GetStatusCode(_loyaltyRatesResponse);
            Assert.AreEqual(responseCode, numericStatusCode);
        }

        [Then(@"I should be able to see (.*) in the Get Loyalty Rates Extension response")]
        public void IShouldSeeTextInGetLoyaltyRatesExtResponse(int responseCode)
        {
            int numericStatusCode = common.GetStatusCode(_loyaltyRatesResponse);
            Assert.AreEqual(responseCode, numericStatusCode);
        }

    }
}
