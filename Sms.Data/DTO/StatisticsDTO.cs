using System;
using System.ComponentModel.DataAnnotations;

namespace Sms.Data.DTO
{
    public class StatisticsDTO
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime day { get; set; }
        public string mcc { get; set; }

        public decimal pricePerSMS { get; set; }
        public int count { get; set; }
        public decimal totalPrice { get; set; }
    }
}
