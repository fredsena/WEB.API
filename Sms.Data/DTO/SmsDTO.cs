
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml;
﻿using Sms.Domain.Enum;

namespace Sms.Data.DTO
{
    [DataContract(Name = "SMS")]
    public class SmsDTO
    {
        [DataMember(Name = "dateTime")]
        public DateTimeOffset dateTime { get; set; }

        [DataMember(Name = "mcc")]
        public string mcc { get; set; }

        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "to")]
        public string to { get; set; }

        [DataMember(Name = "price")]
        public decimal price { get; set; }

        [DataMember(Name = "state")]
        public Status state { get; set; }
    }
}