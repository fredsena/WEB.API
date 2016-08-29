﻿using Sms.Domain.Enum;

namespace Sms.Domain.Interfaces
{
    public interface ISmsSender
    {
        Status SendSms(Sms sms);
    }
}