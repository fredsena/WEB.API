using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sms.Data.Models
{
    public partial class SmsTransaction
    {
        public int SmsTransactionId { get; set; }
        public string From { get; set; }
        public string to { get; set; }
        public string message { get; set; }
        public System.DateTime DateTransaction { get; set; }
        public string MobileCountryCode { get; set; }
        public Decimal SmsPrice { get; set; }
        public bool Status { get; set; }
    }
}
