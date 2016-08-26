using System;
using System.Collections.Generic;

namespace Sms.Data.Models
{
    public partial class SmsTransaction
    {
        public int SmsTransactionId { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string message { get; set; }
        public System.DateTime DateTransaction { get; set; }
        public bool Status { get; set; }
    }
}
