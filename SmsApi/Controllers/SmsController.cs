using SmsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmsApi.Controllers
{
    public class SmsController : ApiController
    {

        //var repo = new CountingKsRepository(new CountingKsContext());

        //var results = repo.GetAllFoodsWithMeasures()
        //                  .Take(25)
        //                  .ToList();
        
        
        [ActionName("countries.json")]
        public IHttpActionResult GetCountriesJson()       
        {
            return Ok(getCountries());
        }

        [ActionName("countries.xml")]
        public IHttpActionResult GetCountriesXml()
        {
            return Content(HttpStatusCode.OK, getCountries(), Configuration.Formatters.XmlFormatter);
        }

        private List<Country> getCountries()
        {
            //mcc { get; set; }
            //cc { get; set; }
            //name { get; set; }
            //pricePerSMS { get; set; }

            List<Country> countries = new List<Country>();
            countries.Add(new Country { mcc = "262", cc = "49", name="Germany", pricePerSMS = 0.055m });
            countries.Add(new Country { mcc = "232", cc = "43", name = "Austria", pricePerSMS = 0.053m });
            countries.Add(new Country { mcc = "260", cc = "48", name = "Poland", pricePerSMS = 0.032m });

            return countries;
        }
    }
}
