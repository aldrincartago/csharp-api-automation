using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using TechTalk.SpecFlow;

namespace APITest
{
    [Binding]
    public sealed class RefundSteps: Refund
    {
        Common common = new Common();

        [Given(@"I use (.*) for the Refund-Reverse")]
        public void IUseTextForTheRefundReverse(string _pnr)
        {
            PutReverseRefundUsingPNR(_pnr);
        }

        [Then(@"I should be able to see (.*) in the Refund Reverse response")]
        public void ThenIShouldBeAbleToSeeTextInGetBooking(int responseCode)
        {
            int numericStatusCode = common.GetStatusCode(_refundReverseResponse);
            Assert.AreEqual(responseCode, numericStatusCode);
        }
    }
}
