using System;
using System.Collections.Generic;

namespace RestSharpDemo
{
    public class Address
    {
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public List<string> addressLines { get; set; }
        public string postalCode { get; set; }
        public string poBox { get; set; }
    }

    public class Phone
    {
        public int type { get; set; }
        public string countryCode { get; set; }
        public string number { get; set; }
    }

    public class Card
    {
        public string id { get; set; }
        public int cardStatus { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expirationDate { get; set; }
    }

    public class MemberProfile
    {
        public string memberInternalId { get; set; }
        public string buyingUnitInternalId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int title { get; set; }
        public string email { get; set; }
        public DateTime birthDate { get; set; }

        public bool Contains(string v)
        {
            throw new NotImplementedException();
        }

        public Address address { get; set; }
        public int gender { get; set; }
        public int memberStatus { get; set; }
        public List<Phone> phones { get; set; }
        public List<Card> cards { get; set; }
        public DateTime startDate { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime updatedDate { get; set; }
        public DateTime marketingPermissionConfirmationDate { get; set; }
        public DateTime privacyPolicyConfirmationDate { get; set; }
        public bool emailConfirmationFlag { get; set; }
        public bool mobilePhoneConfirmationFlag { get; set; }
        public string facebookId { get; set; }
        public string facebookEmail { get; set; }
    }

    public class ProfileResponseData
    {
        public MemberProfile memberProfile { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string referenceCode { get; set; }
    }

    public class ProfileError
    {
        public int code { get; set; }
        public string detail { get; set; }
    }

    public class ProfileData
    {
        public int responseCode { get; set; }
        public string responseDescription { get; set; }
        public ProfileResponseData responseData { get; set; }
        public ProfileError error { get; set; }
        public string message { get; set; }
        public string accountID { get; set; }
    }

}
