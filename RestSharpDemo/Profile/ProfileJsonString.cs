using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Profile
{
    public class ProfileJsonString
    {
        private static Random random = new Random();
        public static int randomCardNumber = random.Next(100000);

        //public string validProfileRegisterBody()
        //{
        //    string registerBody = @"{
        //                ""memberProfile"": {
        //                ""firstName"": ""John"",
        //                ""lastName"": ""Lynch"",
        //                ""title"": 0,
        //                ""birthDate"": ""1980-12-31T00:00:00"",
        //                ""address"": {
        //                    ""country"": ""99"",
        //                    ""state"": ""0"",
        //                    ""city"": ""Makati City"",
        //                    ""addressLines"": [
        //                        ""0000"",
        //                        ""Palanca St."",
        //                        """"
        //                    ],
        //                    ""postalCode"": ""1999"",
        //                    ""poBox"": """"
        //                },
        //                ""gender"": 2,
        //                ""memberStatus"": 1,
        //                ""phonePrefix"": "" +63"",
        //                ""workPhoneNumber"": 9170001234,
        //                ""cards"": [],
        //                ""startDate"": ""2019-05-22T00:00:00"",
        //                ""effectiveDate"": ""2019-05-30T08:03:05.3517288+08:00"",
        //                ""updatedDate"": ""2019-05-30T08:03:05.3517288+08:00"",
        //                ""marketingPermissionConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
        //                ""privacyPolicyConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
        //                ""emailConfirmationFlag"": false,
        //                ""mobilePhoneConfirmationFlag"": false,
        //                ""facebookId"": """"
        //            },
        //        ""email"": ""automatedemail" + randomCardNumber + @"@yahoo.com"",
        //        ""mobileNumber"": ""91788" + randomCardNumber + @""",
        //        ""password"": ""test123""
        //    }";
        //    return registerBody;
        //}

        public string validProfileRegisterBody()
        {
            string registerBody = @"{
                                    ""LoyaltyId"": ""2000" + randomCardNumber + @""",
                                    ""Email"": ""test20191" + randomCardNumber + @"@test.com"",
                                    ""Title"": ""MISS"",
                                    ""FirstName"": ""Test"",
                                    ""LastName"": ""Data"",
                                    ""Status"": ""A"",
                                    ""Birthday"": ""19820617"",
                                    ""Gender"": ""1"",
                                    ""Country"": ""PHL"",
                                    ""Address"": ""Ayala"",
                                    ""City"": ""Makati"",
                                    ""PostalCode"": ""4102"",
                                    ""Phone"": ""63-2-1234567"",
                                    ""Mobile"": ""63-2-1234567"",
                                    ""Nationality"": ""PHL""
                                 }";
            return registerBody;
        }

        //public string updateProfileBody = @"{
        //                ""memberProfile"": {
        //                    ""memberInternalId"": ""4114652"",
        //                    ""buyingUnitInternalId"": ""4115311"",
        //                    ""firstName"": ""Pluto01"",
        //                    ""lastName"": ""Automation01"",
        //                    ""title"": 0,
        //                    ""birthDate"": ""1990-12-01T00:00:00"",
        //                    ""address"": {
        //                        ""country"": ""99"",
        //                        ""state"": ""0"",
        //                        ""city"": ""Makati City"",
        //                        ""addressLines"": [
        //                            ""0000"",
        //                            ""Palanca St."",
        //                            """"
        //                        ],
        //                        ""postalCode"": ""1007"",
        //                        ""poBox"": """"
        //                    },
        //                    ""gender"": 2,
        //                    ""memberStatus"": 1,
        //                    ""phonePrefix"": 356,
        //                    ""workPhoneNumber"": 9178894698,
        //                    ""cards"": [
        //                        {
        //                            ""id"": ""8110009900004418"",
        //                            ""isPrimaryCard"": true,
        //                            ""cardStatus"": 1,
        //                            ""issueDate"": ""2019-07-25T00:00:00"",
        //                            ""effectiveDate"": ""2019-07-25T00:00:00"",
        //                            ""expirationDate"": ""2056-12-31T00:00:00""
        //                        }
        //                    ],
        //                    ""startDate"": ""2019-07-23T00:00:00"",
        //                    ""effectiveDate"": ""2019-07-23T00:00:00"",
        //                    ""updatedDate"": ""2019-07-24T00:00:00"",
        //                    ""marketingPermissionConfirmationDate"": ""2019-07-23T00:00:00"",
        //                    ""privacyPolicyConfirmationDate"": ""2019-07-23T00:00:00"",
        //                    ""emailConfirmationFlag"": false,
        //                    ""mobilePhoneConfirmationFlag"": false,
        //                    ""facebookId"": """",
        //                    ""travelGroup"": []
        //                }
        //            }";

        public string updateProfileBody()
        {
            string updateBody = @"{
                                    ""LoyaltyId"": ""2000110179"",
                                    ""Email"": ""test20191104_01@test.com"",
                                    ""Title"": ""MISS"",
                                    ""FirstName"": ""Test"",
                                    ""LastName"": ""Data"",
                                    ""Status"": ""A"",
                                    ""Birthday"": ""19820617"",
                                    ""Gender"": ""1"",
                                    ""Country"": ""PHL"",
                                    ""Address"": ""TestStreet"",
                                    ""City"": ""Bacoor"",
                                    ""PostalCode"": ""4102"",
                                    ""Phone"": ""63-2-1234567"",
                                    ""Mobile"": ""63-2-1234567"",
                                    ""Nationality"": ""PHL""
                                }";
            return updateBody;
        }

        public string ProfileRegisterExistingEmail = @"{
                        ""memberProfile"": {
                        ""firstName"": ""John"",
                        ""lastName"": ""Lynch"",
                        ""title"": 0,
                        ""birthDate"": ""1980-12-31T00:00:00"",
                        ""address"": {
                            ""country"": ""99"",
                            ""state"": ""0"",
                            ""city"": ""Makati City"",
                            ""addressLines"": [
                                ""0000"",
                                ""Palanca St."",
                                """"
                            ],
                            ""postalCode"": ""1999"",
                            ""poBox"": """"
                        },
                        ""gender"": 2,
                        ""memberStatus"": 1,
                        ""phonePrefix"": "" +63"",
                        ""workPhoneNumber"": 9170001234,
                        ""cards"": [],
                        ""startDate"": ""2019-05-22T00:00:00"",
                        ""effectiveDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""updatedDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""marketingPermissionConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""privacyPolicyConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""emailConfirmationFlag"": false,
                        ""mobilePhoneConfirmationFlag"": false,
                        ""facebookId"": """"
                    },
                ""email"": ""tester@yahoo.com"",
                ""mobileNumber"": ""91700" + randomCardNumber.ToString() + @""",
                ""password"": ""test123""
            }";

        public string invalidProfileRegisterBody = @"{
                        ""memberProfile"": {
                        ""firstName"": ""John"",
                        ""lastName"": ""Lynch"",
                        ""title"": 0,
                        ""birthDate"": ""1980-12-31T00:00:00"",
                        ""address"": {
                            ""country"": ""99"",
                            ""state"": ""0"",
                            ""city"": ""Makati City"",
                            ""addressLines"": [
                                ""0000"",
                                ""Palanca St."",
                                """"
                            ],
                            ""postalCode"": ""1999"",
                            ""poBox"": """"
                        },
                        ""gender"": 2,
                        ""memberStatus"": 1,
                        ""phonePrefix"": "" +63"",
                        ""workPhoneNumber"": 9170001234,
                        ""cards"": [
                                {
                                    ""id"": ""8110009900000000"",
                                    ""isPrimaryCard"": true,
                                    ""cardStatus"": 1,
                                    ""issueDate"": ""2019-06-10T00:00:00"",
                                    ""effectiveDate"": ""2019-06-10T14:35:14.0053399+08:00"",
                                    ""expirationDate"": ""2056-12-31T00:00:00""
                                }],
                        ""startDate"": ""2019-05-22T00:00:00"",
                        ""effectiveDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""updatedDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""marketingPermissionConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""privacyPolicyConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""emailConfirmationFlag"": false,
                        ""mobilePhoneConfirmationFlag"": false,
                        ""facebookId"": """"
                    },
                ""email"": ""invalidRegister" + randomCardNumber.ToString() + @"@yahoo.com"",
                ""mobileNumber"": ""91700" + randomCardNumber.ToString() + @""",
                ""password"": ""test123""
            }";

        public string migrateProfileBody = @"{
                            ""memberCardId"": ""8110009900001023"",
                            ""email"": ""aldrin.cartago@yahoo.com"",
                            ""mobileNumber"": ""9176733294"",
                            ""password"": ""test123"",
                        }";

        public string validOTPBody = @"{
                            ""otpMedium"": ""639212036886"",
                            ""otpChannel"": ""Sms""
                        }";

        public string emptyMobileNumberBody = @"{
                        ""memberProfile"": {
                        ""memberInternalId"": ""4112257"",
                        ""buyingUnitInternalId"": ""4112916"",
                        ""firstName"": ""Newton"",
                        ""lastName"": ""AutoTest5"",
                        ""title"": 0,
                        ""birthDate"": ""1992-10-23T00:00:00"",
                        ""address"": {
                            ""country"": ""46"",
                            ""state"": ""0"",
                            ""city"": ""Paranaque City"",
                            ""addressLines"": [
                                ""0000"",
                                ""Jesuit St."",
                                """"
                            ],
                            ""postalCode"": ""1700"",
                            ""poBox"": """"
                        },
                        ""gender"": 2,
                        ""memberStatus"": 1,
                        ""phonePrefix"": "" + 63"",
                        ""workPhoneNumber"": 0,
                        ""cards"": [],
                        ""startDate"": ""2019-05-22T00:00:00"",
                        ""effectiveDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""updatedDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""marketingPermissionConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""privacyPolicyConfirmationDate"": ""2019-05-30T08:03:05.3517288+08:00"",
                        ""emailConfirmationFlag"": false,
                        ""mobilePhoneConfirmationFlag"": false,
                        ""facebookId"": """"
                    },
                ""email"": ""nonumber@yahoo.com"",
                ""mobileNumber"": """",
                ""password"": ""test123""
            }";

        public string jsonOTP = @"{
                            ""otpMedium"": ""639212036886"",
                            ""otpChannel"": ""Sms""
                        }";

        public string authUsernameBody = @"{
                            ""username"": ""09269979186""
                        }";

        public static int cardNumber { get; private set; }
    }
}
