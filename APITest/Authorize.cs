using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpDemo;
using RestSharpDemo.Authorize;
namespace APITest
{
    [TestClass]
    public class Authorize
    {
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();
        AuthJsonString authString = new AuthJsonString();
        Common common = new Common();
        public UserData loginContent, getUserContent;
        public string JWT = string.Empty;
        public IRestResponse loginResponse;

        public void Login(string username, string password)
        {
            var restUrl = restApi.SetUrl(authString._devBaseUrl, authString.loginUserUrl);
            var restRequest = restApi.CreatePostRequest(authString.loginCredentials(username, password));
            var response = restApi.GetResponse(restUrl, restRequest);

            loginResponse = response;
            loginContent = restApi.GetContent<UserData>(response);

            if(loginContent.responseDescription == "Success")
            {
                JWT = loginContent.responseData.token;
            }

        }

        public void GetUser(string username) //Verify that the user is in the DB
        {
            var restUrl = restApi.SetUrl(authString._devBaseUrl, authString.getUserUrl(username));
            var restRequest = restApi.CreateGetRequestWithParameter(username);
            var response = restApi.GetResponse(restUrl, restRequest);

            getUserContent = restApi.GetContent<UserData>(response);
        }
    }
}

