using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITest
{
    [Binding]
    public class AuthorizeSteps : Authorize
    {
        Common common = new Common();

        [Given(@"I login using (.*) , (.*) as my credentials")]
        public void GivenILoginUsingUsernamePassword(string username, string password)
        {
            Login(username, password);
        }

        [Given(@"I find the user (.*) in the Auth DB")]
        public void GivenIFindTheUserTextInAuthDB(string username)
        {
            GetUser(username);
        }

        [Then(@"I should be able to see (.*) in the Login response")]
        public void ThenIShouldBeAbleToSeeTextInLogin(int responseCode)
        {
            int numericStatusCode = common.GetStatusCode(loginResponse);
            Assert.AreEqual(responseCode, numericStatusCode);
        }

        [Then(@"I should be able to see (.*) in the Get User response")]
        public void ThenIShouldBeAbleToSeeTextInGetUser(string username)
        {
            Assert.AreEqual(getUserContent.responseData.username, username);
            Assert.IsTrue(getUserContent.responseData.isExisting);
        }
    }
}
