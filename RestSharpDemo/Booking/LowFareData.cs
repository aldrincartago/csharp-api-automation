using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Booking
{
    public class ResponseData
    {
        public LowFareCalendar lowFareCalendar { get; set; }
    }

    public class RootObject
    {
        public int responseCode { get; set; }
        public string responseDescription { get; set; }
        public ResponseData responseData { get; set; }
    }
}
