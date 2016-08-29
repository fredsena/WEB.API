﻿using System;
using System.Linq;
using Sms.Domain;
using Sms.Domain.Enum;
using Sms.Data.DTO;
using Sms.Data.Models;
using System.Collections.Generic;

namespace Sms.Data.Repository
{
    public class Repository : IRepository, IDisposable
    {
        private dbSMSContext _context;
        public Repository(dbSMSContext context)
        {
            _context = context;
        }

        public IQueryable<SmsTransaction> GetAllSMSSent()
        {
            return _context.SmsTransactions;
        }

        public IList<CountryDTO> GetAllCountries()
        {
            return (from c in _context.CountrySms
                    select new CountryDTO()
                    {
                        mcc = c.MobileCountryCode,
                        cc = c.CountryCode,
                        name = c.CountryName,
                        pricePerSMS = c.SmsPrice

                    }).ToList();
        }

        public Status SendSMS(Sms.Domain.Sms sms)
        {
            var sender = new SmsSender();
            
            Status status = sender.send(sms);

            RegisterSmsTransaction(sms,status);

            return status;
        }

        public SentSMSDTO GetSentSMS(DateTimeOffset dateTimeFrom, DateTimeOffset dateTimeTo, int skip, int take)
        {
            var query = (from s in _context.SmsTransactions
                         where s.DateTransaction >= dateTimeFrom && s.DateTransaction <= dateTimeTo
                         select new SmsDTO()
                         {
                             dateTime = s.DateTransaction,
                             mcc = s.MobileCountryCode,
                             From = s.From,
                             to = s.to,
                             price = s.SmsPrice,
                             state = s.Status == false ? Status.Failed : Status.Success

                         }).ToList().Skip(skip).Take(take);

            var total = query.Count();

            return new SentSMSDTO
            {
                totalCount = total,
                smsList = query.ToList()
            };
        }

        public IEnumerable<StatisticsDTO> GetStatistics(DateTime dateFrom, DateTime dateTo, string mccList)
        {
            IEnumerable<StatisticsDTO> statistics;
            
            string list = string.Empty;

            if (!string.IsNullOrWhiteSpace(mccList))
            {
                list = String.Format(" AND MobileCountryCode in ({0}) ", mccList);
            }          

            string query = String.Format(@"          

            SELECT
                dateadd(DAY,0, datediff(day,0, DateTransaction)) day, 
                MobileCountryCode mcc, 
                cast(SmsPrice as decimal(10,2)) pricePerSMS, 
                Count(MobileCountryCode) count, 
                cast(Sum(SmsPrice) as decimal(10,2)) totalPrice
            FROM [dbo].[SmsTransaction] 	
            WHERE dateadd(DAY,0, datediff(day,0, DateTransaction)) BETWEEN '{0}' AND '{1}' {2} 
            AND Status = 1
            GROUP BY dateadd(DAY,0, datediff(day,0, DateTransaction)), MobileCountryCode, SmsPrice ", 
                dateFrom.ToString("yyyy-MM-dd"), dateTo.ToString("yyyy-MM-dd"), list);

            statistics = _context.Database.SqlQuery<StatisticsDTO>(query);

            return statistics;
        }

        public bool IsCountryAndMobileCodeValid(string CountryCode, string MobileCountryCode)
        {
            return _context.CountrySms.Where(m => m.CountryCode.Equals(CountryCode) && m.MobileCountryCode.Equals(MobileCountryCode)).Any();
        }

        public Decimal GetActualPriceFromCountryAndMobileCode(string CountryCode, string MobileCountryCode)
        {
            var row = _context.CountrySms.SingleOrDefault(m => m.CountryCode.Equals(CountryCode) && m.MobileCountryCode.Equals(MobileCountryCode));
            return row != null ? row.SmsPrice : 0;
        }

        public void RegisterSmsTransaction(Sms.Domain.Sms sms, Status status)
        {
            string CountryCode = sms.to.Substring(1, 2);
            string MobileCountryCode = sms.to.Substring(3, 3);

            SmsTransaction tran = new SmsTransaction();

            tran.DateTransaction = DateTime.Now;
            tran.From = sms.from;
            tran.to = sms.to;
            tran.message = sms.text;
            tran.Status = status == Status.Success ? true : false;
            tran.MobileCountryCode = MobileCountryCode;
            tran.SmsPrice = GetActualPriceFromCountryAndMobileCode(CountryCode, MobileCountryCode);
            
            _context.SmsTransactions.Add(tran);
            _context.SaveChanges();
            
        }

        public void Dispose()
        {
            if (_context != null)
                _context = null;
        }
    }
}