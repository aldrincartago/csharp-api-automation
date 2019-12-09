using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using TechTalk.SpecFlow;

namespace APITest
{
    [Binding]
    public sealed class SkySalesSteps : SkySales
    {
        Common common = new Common();

        [Given(@"I use (.*) as the PNR")]
        public void IUseTextAsThePNR(string _pnr)
        {
            GetSkySalesUsingPNR(_pnr);
        }

        [Given(@"I use (.*) as the PNR of Get Skysale Data")]
        public void IUseTextAsPNRSkysaleData(string _pnr)
        {
            GetSkySalesUsingPNR(_pnr);
        }

        [Given(@"I use (.*) as the promo code")]
        public void IUseTextAsPromoCode(string _promoCode)
        {
            GetPromoCodeUsage(_promoCode);
        }

        [Then(@"I should be able to see (.*) in the Get SkySales response")]
        public void ThenIShouldBeAbleToSeeTextInGetBooking(int responseCode)
        {
            int numericStatusCode = common.GetStatusCode(_skySalesResponse);
            Assert.AreEqual(responseCode, numericStatusCode);
        }
    }
}
