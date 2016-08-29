using System;
using System.Collections.Generic;
using System.Linq;
using Sms.Data.DTO;
using Sms.Domain.Enum;

namespace Sms.Data.Repository
{
    public interface IRepository
    {
        IList<CountryDTO> GetAllCountries();
        Status SendSMS(Sms.Domain.Sms sms);
        SentSMSDTO GetSentSMS(DateTimeOffset dateTimeFrom, DateTimeOffset dateTimeTo, int skip, int take);
        IEnumerable<StatisticsDTO> GetStatistics(DateTime dateFrom, DateTime dateTo, string mccList);
        bool IsCountryAndMobileCodeValid(string CountryCode, string MobileCountryCode);
    }
}
