using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.CalculateService;

namespace APITest
{
    //[TestClass]
    public class Communication
    {
        Comm OTP = new Comm();

        [TestMethod]
        public void SendValidOTP()
        {
            string jsonOTP = @"{
                            ""otpMedium"": ""639212036886"",
                            ""otpChannel"": ""Sms""
                        }";

            var response = OTP.CreatePostRequest("/sendotp", jsonOTP);
            Assert.AreEqual(response.responseDescription, "Success.");
        }

        [TestMethod]
        public void SendInvalidMobileNumber()
        {
            string jsonOTP = @"{
                            ""otpMedium"": ""1234567890"",
                            ""otpChannel"": ""Sms""
                        }";

            var response = OTP.CreatePostRequest("/sendotp", jsonOTP);
            Assert.AreEqual(response.responseDescription, "Invalid.");
        }

        [TestMethod]
        public void SendInvalidChannel()
        {
            string jsonOTP = @"{
                            ""otpMedium"": ""639212036886"",
                            ""otpChannel"": ""00000""
                        }";

            var response = OTP.CreatePostRequest("/sendotp", jsonOTP);
            Assert.AreEqual(response.responseDescription, "Invalid.");
        }

        [TestMethod]
        public void ValidateUsingValidOTP()
        {
            string jsonOTP = @"{
                            ""otpMedium"": ""639212036886"",
                            ""OtpCode"": ""32520""
                        }";

            var response = OTP.CreatePostRequest("/validateotp", jsonOTP);
            Assert.AreEqual(response.responseDescription, "Success.");
        }

        [TestMethod]
        public void ValidateUsingInvalidOTP()
        {
            string jsonOTP = @"{
                            ""otpMedium"": ""639212036886"",
                            ""OtpCode"": ""abcde""
                        }";

            var response = OTP.CreatePostRequest("/validateotp", jsonOTP);
            Assert.AreEqual(response.responseDescription, "Invalid.");
        }


    }
}
