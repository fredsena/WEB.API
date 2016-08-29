﻿using Sms.Domain.Enum;
using Sms.Domain.Interfaces;

namespace Sms.Domain.Services
{
    public class SmsService : ISmsSender
    {
        public Status SendSms(Sms sms)
        {
            //TODO: Implement SMS sender Service
            return Status.Success;
        }
    }
}