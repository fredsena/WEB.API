﻿using Sms.Domain;
using Sms.Domain.Enum;
using Sms.Domain.Interfaces;
using Sms.Domain.Services;
using Sms.Data.Repository;
using Sms.Data.Models;

namespace Sms.Data
{
    public class SmsSender
    {
        ServiceLocator _serviceLocator;

        public Status send(Sms.Domain.Sms sms)
        {
            if (!Validate(sms)) return Status.Failed;

            _serviceLocator = new ServiceLocator();
            _serviceLocator.Register<ISmsSender>(() => (new SmsService()));

            var smsFacade = new SmsFacade(_serviceLocator);

            return smsFacade.Process(sms);
        }

        private bool Validate(Sms.Domain.Sms sms)
        {
            var repository = new Sms.Data.Repository.Repository(new dbSMSContext());

            string CountryCode = sms.to.Substring(1, 2);
            string MobileCountryCode = sms.to.Substring(3, 3);

            return repository.IsCountryAndMobileCodeValid(CountryCode, MobileCountryCode);
        }

    }
}