﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Sms.Data.DTO
{
    [DataContract(Name = "SentSMS")]
    public class SentSMSDTO
    {
        [DataMember(Name = "totalCount")]
        public int totalCount { get; set; }

        [DataMember(Name = "items")]
        public List<SmsDTO> smsList { get; set; }
    }
}