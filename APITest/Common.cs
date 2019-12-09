using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Authorize;
using RestSharpDemo.Profile;
using System.Net;
using RestSharp;

namespace APITest
{
    public class Common : AuthJsonString
    {
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();

        public int GetStatusCode(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            return numericStatusCode;
        }

        public IRestResponse CreatePostRequest(string url, string endpoint, string jsonBody)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.CreatePostRequest(jsonBody);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreateLoyaltyRatesRequest(string url, string endpoint, string _departureStn, string _arrivalStn, string _bookingDate, string _departureDate)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.GetLoyaltyRates(_departureStn, _arrivalStn, _bookingDate, _departureDate);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse GetSkySalesUsingPNR(string url, string endpoint, string _pnr)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.CreateGetSkySalesWithPNR(_pnr);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse PutRefundReverse(string url, string endpoint, string _pnr)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.CreatePutRefundReverseUsingPNR(_pnr);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse GetPromoCodeUsage(string url, string endpoint, string _promoCode)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.CreateGetPromoCodeUsage(_promoCode);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreateLoyaltyRatesExt(string url, string endpoint, string _departureStn, string _arrivalStn)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.GetLoyaltyRatesExt(_departureStn, _arrivalStn);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreateGetMockRates(string url, string endpoint)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.CreateGetMockRatesRequest();
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreatePostRequestWithTokenBody(string url, string endpoint, string token, string jsonBody)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.postRequestWithTokenAndBody(token, jsonBody);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreatePutRequestWithTokenBody(string url, string endpoint, string loyaltyId, string jsonBody)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.putRequestWithTokenAndBody(loyaltyId, jsonBody);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreatePostRequestWithToken(string url, string endpoint, string token)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            var restRequest = restApi.postRequestWithToken(token);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

        public IRestResponse CreateGetRequestWithToken(string url, string endpoint, string token)
        {
            var restUrl = restApi.SetUrl(url, endpoint);
            //var restRequest = restApi.getRequestWithToken(token);
            var restRequest = restApi.CreateGetRequestWithParameter(token);
            var response = restApi.GetResponse(restUrl, restRequest);
            return response;
        }

    }
}
