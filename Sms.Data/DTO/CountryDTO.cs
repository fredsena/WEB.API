﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Sms.Data.DTO
{
    [DataContract(Name = "Country")]
    public class CountryDTO
    {
        [DataMember(Name = "mcc")]
        public string mcc { get; set; }

        [DataMember(Name = "cc")]
        public string cc { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "pricePerSMS")]
        public decimal pricePerSMS { get; set; }
    }
}