using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsApi.Models
{
    public class Country
    {
        public string mcc { get; set; }
        public string cc { get; set; }
        public string name { get; set; }
        public Decimal pricePerSMS { get; set; }
    }
}
