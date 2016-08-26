using System;
using System.Collections.Generic;

namespace Sms.Data.Models
{
    public partial class CountrySm
    {
        public int CountrySmsId { get; set; }
        public string CountryName { get; set; }
        public string MobileCountryCode { get; set; }
        public string CountryCode { get; set; }
        public decimal SmsPrice { get; set; }
    }
}
