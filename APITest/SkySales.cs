using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Profile;
using RestSharp;

namespace APITest
{

    public class SkySales : Common
    {
        public ProfileData registerProfileContent, retrieveProfileContent, updateProfileContent;
        public IRestResponse _skySalesResponse;
        RestApiHelper<UserData> restApi = new RestApiHelper<UserData>();
        public string JWT = string.Empty;


        public void GetSkySalesUsingPNR(string _pnr)
        {
            var response = GetSkySalesUsingPNR(_devBaseUrl, _skySales, _pnr);

            _skySalesResponse = response;
        }

        public void GetSkySaleDataUsingPNR(string _pnr)
        {
            var response = GetSkySalesUsingPNR(_devBaseUrl, _getSkySaleData, _pnr);

            _skySalesResponse = response;
        }

        public void GetPromoCodeUsage(string _promoCode)
        {
            var response = GetPromoCodeUsage(_devBaseUrl, _getPromoCodeUsage, _promoCode);

            _skySalesResponse = response;
        }

        //public void GetMockRates()
        //{
        //    var response = CreateGetMockRates(_devBaseUrl, _getMockRates);

        //    _loyaltyRatesResponse = response;
        //}

        //public void GetLoyaltyRatesExt(string _departureStn, string _arrivalStn)
        //{
        //    var response = CreateLoyaltyRatesExt(_devBaseUrl, _loyaltyRates, _departureStn, _arrivalStn);

        //    _loyaltyRatesResponse = response;
        //}


    }
}
