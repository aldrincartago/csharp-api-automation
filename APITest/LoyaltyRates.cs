using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Profile;
using RestSharp;

namespace APITest
{

    public class LoyaltyRates : Common
    {
        ProfileJsonString jsonString = new ProfileJsonString();
        public ProfileData registerProfileContent, retrieveProfileContent, updateProfileContent;
        public IRestResponse registerProfileResponse, retrieveProfileResponse, updateProfileResponse, _loyaltyRatesResponse;
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();
        public string JWT = string.Empty;
        private IRestResponse resp;

        public void Init(string username, string password)
        {
            var restUrl = restApi.SetUrl(_devBaseUrl, loginUserUrl);
            var restRequest = restApi.CreatePostRequest(loginCredentials(username, password));
            var response = restApi.GetResponse(restUrl, restRequest);
            UserData content = restApi.GetContent<UserData>(response);

            JWT = content.responseData.token;
        }

        public void GetLoyaltyRates(string _departureStn, string _arrivalStn, string _bookingDate, string _departureDate)
        {
            var response = CreateLoyaltyRatesRequest(_devBaseUrl, _loyaltyRates, _departureStn, _arrivalStn, _bookingDate, _departureDate);

            _loyaltyRatesResponse = response;
        }

        public void GetMockRates()
        {
            var response = CreateGetMockRates(_devBaseUrl, _getMockRates);

            _loyaltyRatesResponse = response;
        }

        public void GetLoyaltyRatesExt(string _departureStn, string _arrivalStn)
        {
            var response = CreateLoyaltyRatesExt(_devBaseUrl, _loyaltyRates, _departureStn, _arrivalStn);

            _loyaltyRatesResponse = response;
        }


    }
}
