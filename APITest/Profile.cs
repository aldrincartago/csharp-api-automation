using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Profile;
using RestSharp;

namespace APITest
{

    public class Profile : Common
    {
        ProfileJsonString jsonString = new ProfileJsonString();
        public ProfileData registerProfileContent, retrieveProfileContent, updateProfileContent;
        public IRestResponse registerProfileResponse, retrieveProfileResponse, updateProfileResponse;
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

        public void RegisterProfile()
        {
            var response = CreatePostRequest(_devBaseUrl, registerProfile, jsonString.validProfileRegisterBody());

            registerProfileResponse = response;
            registerProfileContent = restApi.GetContent<ProfileData>(response);
        }

        public void RegisterUsingExistingEmail()
        {
            var response = CreatePostRequest(_devBaseUrl, registerProfile, jsonString.ProfileRegisterExistingEmail);

            registerProfileResponse = response;
            registerProfileContent = restApi.GetContent<ProfileData>(response);
        }
        
        public void RetrieveProfile(string token)
        {
            var response = CreateGetRequestWithToken(_devBaseUrl, retrieveProfile, token);
            retrieveProfileResponse = response;
            retrieveProfileContent = restApi.GetContent<ProfileData>(response);
        }

        //public void UpdateProfile()
        //{
        //    var response = CreatePutRequestWithTokenBody(_devBaseUrl, updateProfile, JWT, jsonString.updateProfileBody);

        //    updateProfileResponse = response;
        //    updateProfileContent = restApi.GetContent<ProfileData>(response);

        //}

        public void UpdateProfile()
        {
            var response = CreatePutRequestWithTokenBody(_devBaseUrl, updateProfile, "2000110179", jsonString.updateProfileBody());

            updateProfileResponse = response;
            updateProfileContent = restApi.GetContent<ProfileData>(response);

        }

        public void RegisterUsingIncorrectCardID()
        {
            var response = CreatePostRequest(_devBaseUrl, registerProfile, jsonString.invalidProfileRegisterBody);

            registerProfileResponse = response;
            registerProfileContent = restApi.GetContent<ProfileData>(response);
        }

        public void RegisterWithoutMobileNumber()
        {
            var restUrl = restApi.SetUrl(_localBaseUrl, registerProfile);
            var restRequest = restApi.CreatePostRequest(jsonString.emptyMobileNumberBody);
            var response = restApi.GetResponse(restUrl, restRequest);
            ProfileData content = restApi.GetContent<ProfileData>(response);
            int numericStatusCode = GetStatusCode(response);

            Assert.AreEqual(400, numericStatusCode);
            if (!content.error.detail.Contains("Error converting value"))
                Assert.Fail("Mobile Number cannot be empty");
        }

        public int getResponseCode(string endpoint)
        {

            if (endpoint == "Register")
            {
                resp = registerProfileResponse;
            }
            else if (endpoint == "Retrieve")
            {
                resp = retrieveProfileResponse;
            }
            else if (endpoint == "Update")
            {
                resp = updateProfileResponse;
            }

            int numericStatusCode = GetStatusCode(resp);
            return numericStatusCode;
        }

    }
}
