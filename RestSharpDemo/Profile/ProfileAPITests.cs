using Newtonsoft.Json;
using RestSharp;

namespace RestSharpDemo
{
    public class ProfileRegister
    {
        string _localBaseUrl = "https://localhost:44338/";

        public ProfileData RegisterProfile(string jsonString)
        {
            var restClient = new RestClient(_localBaseUrl);
            var restRequest = new RestRequest("profile/register", Method.POST);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Ocp-Apim-Subscription-Key", "0686fbd03c0047979e0445b32508ea1b");
            restRequest.AddHeader("Ocp - Apim - Trace", "true");
            restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            ProfileData profileBody = JsonConvert.DeserializeObject<ProfileData>(content);
            return profileBody;
        }

        public ProfileData UpdateProfile(string value, string jsonString)
        {
            var restClient = new RestClient(_localBaseUrl);
            var restRequest = new RestRequest("profile/update", Method.POST);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Ocp-Apim-Subscription-Key", "0686fbd03c0047979e0445b32508ea1b");
            restRequest.AddHeader("Ocp - Apim - Trace", "true");
            restRequest.AddParameter("source", value);
            restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            ProfileData profileBody = JsonConvert.DeserializeObject<ProfileData>(content);
            return profileBody;
        }

        public ProfileData RetrieveProfile()
        {
            var restClient = new RestClient(_localBaseUrl);
            var restRequest = new RestRequest("profile/retrieve", Method.GET);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Ocp-Apim-Subscription-Key", "0686fbd03c0047979e0445b32508ea1b");
            restRequest.AddHeader("Ocp - Apim - Trace", "true");
            restRequest.AddParameter("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE1NTg2MDgwMjgsImV4cCI6MTU1ODYxMTYyOCwiaWF0IjoxNTU4NjA4MDI4LCJpc3MiOiJkYXZpIn0.9DbLgaiY51bFYo2P4ahqsvbqIub7kkRFPq8xpHRbyCI", ParameterType.HttpHeader);


            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            ProfileData profileBody = JsonConvert.DeserializeObject<ProfileData>(content);
            return profileBody;
        }

        public ProfileData AuthenticateProfile(string source, string username)
        {
            var restClient = new RestClient(_localBaseUrl);
            var restRequest = new RestRequest("profile/retrieve", Method.GET);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Ocp-Apim-Subscription-Key", "0686fbd03c0047979e0445b32508ea1b");
            restRequest.AddHeader("Ocp - Apim - Trace", "true");
            restRequest.AddParameter("source", source);
            restRequest.AddParameter("username", username);

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            ProfileData profileBody = JsonConvert.DeserializeObject<ProfileData>(content);
            return profileBody;
        }
    }
}
