using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Authorize;
using RestSharpDemo.Booking;

namespace APITest
{
    //[TestClass]
    public class LowFare
    {
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();
        AuthJsonString authString = new AuthJsonString();
        LowFareJsonString lowFareString = new LowFareJsonString();
        string JWT = string.Empty;

        [TestInitialize]
        public void Init()
        {
            var restUrl = restApi.SetUrl(authString._localBaseUrl, lowFareString.lowFareCredentials);
            var restRequest = restApi.CreatePostRequest(authString.lowFareCredentials);
            var response = restApi.GetResponse(restUrl, restRequest);
            UserData content = restApi.GetContent<UserData>(response);

            JWT = content.responseData.token; //To be called from other classes
        }
        
        [TestMethod]
        public void ValidateLowestFare()
        {
            var restUrl = restApi.SetUrl(authString._devBaseUrl, lowFareString.lowFareUrl);
            var restRequest = restApi.postRequestWithTokenAndBody(JWT, lowFareString.lowestFareBody);
            var response = restApi.GetResponse(restUrl, restRequest);
            UserData content = restApi.GetContent<UserData>(response);

            Assert.AreEqual(content.responseData.isExisting, true);
        }
    }
}
