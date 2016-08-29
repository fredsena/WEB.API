﻿using Sms.Domain.Enum;

namespace Sms.Data.Interfaces
{
    public interface ISmsFacade
    {
        Status Process(Sms.Domain.Sms sms);
    }
}