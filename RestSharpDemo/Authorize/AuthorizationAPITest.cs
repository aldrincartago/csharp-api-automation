using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpDemo
{
    public class RestApiHelper<T>
    {

        public RestClient _restClient;
        public RestRequest _restRequest;
        //public string subscriptionKey = "a92a425fbe1b40abb2ebbd2dd333d178";
        public string subscriptionKey = "666ad8a8ff1c4bc5b7e4a62ce9f9f5da";


        public RestClient SetUrl(string baseUrl,string resourceUrl)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var url = Path.Combine(baseUrl, resourceUrl);
            var _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest CreatePostRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            _restRequest.AddHeader("Ocp-Apim-Trace", "true");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            return _restRequest;
        }

        //public RestRequest CreateGetRequestWithParameter(string username)
        //{
        //    _restRequest = new RestRequest(Method.GET);
        //    _restRequest.AddHeader("Content-Type", "application/json");
        //    _restRequest.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
        //    _restRequest.AddHeader("Ocp-Apim-Trace", "true");
        //    _restRequest.AddParameter("username", username);
        //    return _restRequest;
        //}

        public RestRequest CreateGetRequestWithParameter(string loyaltyId)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddParameter("loyaltyId", loyaltyId);
            return _restRequest;
        }

        public RestRequest CreateGetSkySalesWithPNR(string _pnr)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddParameter("pnr", _pnr);
            return _restRequest;
        }

        public RestRequest CreatePutRefundReverseUsingPNR(string _pnr)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddParameter("pnr", _pnr, ParameterType.QueryString);
            _restRequest.AddParameter("status", "queue", ParameterType.QueryString);
            return _restRequest;
        }

        public RestRequest CreateGetPromoCodeUsage(string _promoCode)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddParameter("promoCode", _promoCode);
            return _restRequest;
        }

        public RestRequest CreateGetMockRatesRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            return _restRequest;
        }

        public RestRequest postRequestWithTokenAndBody(string token, string jsonString)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            _restRequest.AddHeader("Ocp-Apim-Trace", "true");
            _restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            return _restRequest;
        }

        //public RestRequest putRequestWithTokenAndBody(string token, string jsonString)
        //{
        //    _restRequest = new RestRequest(Method.PUT);
        //    _restRequest.AddHeader("Content-Type", "application/json");
        //    _restRequest.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
        //    _restRequest.AddHeader("Ocp-Apim-Trace", "true");
        //    _restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);
        //    _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

        //    return _restRequest;
        //}

        public RestRequest putRequestWithTokenAndBody(string loyaltyId, string jsonString)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddParameter("loyaltyId", loyaltyId, ParameterType.QueryString);
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            return _restRequest;
        }

        public RestRequest GetLoyaltyRates(string _departureStn, string _arrivalStn, string _bookingDate, string _departureDate)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddParameter("departureStn", _departureStn, ParameterType.QueryString);
            _restRequest.AddParameter("arrivalStn", _arrivalStn, ParameterType.QueryString);
            _restRequest.AddParameter("bookingDate", _bookingDate, ParameterType.QueryString);
            _restRequest.AddParameter("departureDate", _departureDate, ParameterType.QueryString);

            return _restRequest;
        }

        public RestRequest GetLoyaltyRatesExt(string _departureStn, string _arrivalStn)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddParameter("departureStn", _departureStn, ParameterType.QueryString);
            _restRequest.AddParameter("arrivalStn", _arrivalStn, ParameterType.QueryString);

            return _restRequest;
        }

        public RestRequest postRequestWithToken(string token)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            _restRequest.AddHeader("Ocp-Apim-Trace", "true");
            _restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            return _restRequest;
        }

        public RestRequest getRequestWithToken(string token)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            _restRequest.AddHeader("Ocp-Apim-Trace", "true");
            _restRequest.AddParameter("Authorization", "Bearer " + token, ParameterType.HttpHeader);

            return _restRequest;
        }

        public RestRequest CreatePutRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deseiralizeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(content);
            return deseiralizeObject;
        }
    }
}
