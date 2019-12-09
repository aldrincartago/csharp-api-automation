using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class UserData
    {
        public int responseCode { get; set; }
        public string accountID { get; set; }
        public string responseDescription { get; set; }
        public string message { get; set; }
        public string requestID { get; set; }
        public ResponseData responseData { get; set; }
        public Error error { get; set; }
    }

    public class ResponseData
    {
        public string username { get; set; }
        public bool isExisting { get; set; }
        public string token { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string detail { get; set; }
    }

}
