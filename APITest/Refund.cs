using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Profile;
using RestSharp;

namespace APITest
{

    public class Refund : Common
    {
        public ProfileData registerProfileContent, retrieveProfileContent, updateProfileContent;
        public IRestResponse _refundReverseResponse;
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();
        public string JWT = string.Empty;


        public void PutReverseRefundUsingPNR(string _pnr)
        {
            var response = PutRefundReverse(_devBaseUrl, _refundReverse, _pnr);

            _refundReverseResponse = response;
        }

    }
}
