﻿using SmsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sms.Data;
using Sms.Data.Repository;
using Sms.Data.Models;
using Sms.Data.DTO;
using System.Web.Http.Results;
using Sms.Domain;
using Sms.Domain.Enum;

namespace SmsApi.Controllers
{
    public class SmsController : ApiController
    {
        [ActionName("countries.json")]
        public IHttpActionResult GetCountriesJson()
        {
            return Ok(GetCountries());
        }

        [ActionName("countries.xml")]
        public IHttpActionResult GetCountriesXml()
        {
            return Content(HttpStatusCode.OK, GetCountries(), Configuration.Formatters.XmlFormatter);
        }

        [ActionName("send.json")]
        [AcceptVerbs("GET","POST")]
        public IHttpActionResult SendSMSJson([FromUri] SendSmsRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SendSMS(model.from, model.to, model.text);

                if (result == Status.Success)
                    return Content(HttpStatusCode.OK, "Sucess");
                else
                    return Content(HttpStatusCode.NotFound, "Failed: Sms could not be sent to phone number: " + model.to);
            }
            else
            {
                return BadRequest("Invalid data: (tip): include %2B (= symbol (+)) in the beginning of the number");
            }
        }

        [ActionName("send.xml")]
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult SendSMSXml([FromUri] SendSmsRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SendSMS(model.from, model.to, model.text);

                if (result == Status.Success)
                    return Content(HttpStatusCode.OK, "Sucess", Configuration.Formatters.XmlFormatter);
                else
                    return Content(HttpStatusCode.NotFound, "Failed: Sms could not be sent to phone number: " + model.to, Configuration.Formatters.XmlFormatter);
            }
            else
            {
                return BadRequest("Invalid data: (tip): include %2B (= symbol (+)) in the beginning of the number");
            }
        }

        [ActionName("sent.json")]
        public IHttpActionResult GetSentSMSJson([FromUri] SentSMSRequestModel model)
        {

            if (ModelState.IsValid)
                return Ok(GetSentSMS(model.dateTimeFrom, model.dateTimeTo, model.skip, model.take));
            else
                return BadRequest("Invalid parameters");

        }

        [ActionName("sent.xml")]
        public IHttpActionResult GetSentSMSXml([FromUri] SentSMSRequestModel model)
        {
            if (ModelState.IsValid)
                return Content(HttpStatusCode.OK, GetSentSMS(model.dateTimeFrom, model.dateTimeTo, model.skip, model.take), Configuration.Formatters.XmlFormatter);
            else
                return BadRequest("Invalid parameters");
        }


        [ActionName("statistics.json")]
        public IHttpActionResult GetStatisticsJson([FromUri] StatisticsRequestModel model)
        {
            if (ModelState.IsValid)
                return Ok(GetStatistics(model.dateFrom, model.dateTo, model.mccList));
            else
                return BadRequest("Invalid parameters");
        }

        [ActionName("statistics.xml")]
        public IHttpActionResult GetStatisticsXml([FromUri] StatisticsRequestModel model)
        {
            if (ModelState.IsValid)
                return Content(HttpStatusCode.OK, GetStatistics(model.dateFrom, model.dateTo, model.mccList), Configuration.Formatters.XmlFormatter);
            else
                return BadRequest("Invalid parameters");
        }


        private IList<CountryDTO> GetCountries()
        {
            var repository = new Repository(new dbSMSContext());
            return repository.GetAllCountries();
        }

        private Status SendSMS(string from, string to, string text)
        {
            var sms = new Sms.Domain.Sms() { from = from, to = to, text = text };

            var repository = new Repository(new dbSMSContext());

            return repository.SendSMS(sms);
        }


        private SentSMSDTO GetSentSMS(DateTimeOffset dateTimeFrom, DateTimeOffset dateTimeTo, int skip, int take)
        {
            var repository = new Repository(new dbSMSContext());

            return repository.GetSentSMS(dateTimeFrom, dateTimeTo, skip, take);
        }

        private IEnumerable<StatisticsDTO> GetStatistics(DateTime dateFrom, DateTime dateTo, string mccList)
        {
            var repository = new Repository(new dbSMSContext());

            return repository.GetStatistics(dateFrom, dateTo, mccList);
        }

    }
}