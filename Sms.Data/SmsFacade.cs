﻿using Sms.Data;
using Sms.Domain.Enum;
using Sms.Data.Interfaces;
using System;
using Sms.Domain.Interfaces;

namespace Sms.Domain
{
    public class SmsFacade : ISmsFacade
    {
        private readonly IServiceLocator serviceLocator;

        public SmsFacade(ServiceLocator serviceLocator)
        {
            if (serviceLocator == null)
            {
                throw new ArgumentException("serviceLocator null");
            }

            this.serviceLocator = serviceLocator;
        }

        public Status Process(Sms sms)
        {
            var sender = this.serviceLocator.Resolve<ISmsSender>();
            return sender.SendSms(sms);
        }

    }
}