using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using TechTalk.SpecFlow;

namespace APITest
{
    [Binding]
    public class ProfileSteps : Profile
    {
        [BeforeScenario("profile")]
        public void Initialize()
        {
            Init("pluto01@tester.com", "test123");
        }

        [Given(@"I register using a valid Profile request body")]
        public void GivenIRegisterUsingAValidRequestBody()
        {
            RegisterProfile();
        }

        [Given(@"I retrieve a valid profile")]
        public void GivenIRetrieveAProfile()
        {
            //RetrieveProfile(JWT);
            RetrieveProfile("test");
        }

        [Given(@"I update a profile")]
        public void GivenIUpdateAProfile()
        {
            UpdateProfile();
        }

        [Given(@"I register using an existing email address")]
        public void RegisterUsingAnExistingEmail()
        {
            RegisterUsingExistingEmail();
        }

        [Given(@"I register using an invalid card ID number")]
        public void RegisterUsingInvalidCardNumber()
        {
            RegisterUsingIncorrectCardID();
        }

        [Then(@"I should be able to see (.*) in the (.*) response status")]
        public void ThenIShouldSeeIntInResponseStatus(int responseStatus, string endpoint)
        {
            Assert.AreEqual(responseStatus, getResponseCode(endpoint));
        }

    }
}
