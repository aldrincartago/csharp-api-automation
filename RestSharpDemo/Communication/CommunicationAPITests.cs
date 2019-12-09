using Newtonsoft.Json;
using RestSharp;

namespace RestSharpDemo
{
    public class Comm
    {
        public string _baseUrl = "https://dev-gorewards-api.apps.bcstechnology.com.au";

        public CommData CreatePostRequest(string postUrl, string jsonString)
        {
            var restClient = new RestClient(_baseUrl);
            var restRequest = new RestRequest(postUrl, Method.POST);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Ocp-Apim-Subscription-Key", "0686fbd03c0047979e0445b32508ea1b");
            restRequest.AddHeader("Ocp - Apim - Trace", "true");
            restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);

            IRestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            CommData comm = JsonConvert.DeserializeObject<CommData>(content);
            return comm;
        }

    }
}
