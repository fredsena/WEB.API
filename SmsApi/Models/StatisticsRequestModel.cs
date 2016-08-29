using System;
using System.ComponentModel.DataAnnotations;

namespace SmsApi.Models
{
    public class StatisticsRequestModel
    {
        [Required]
        public DateTime dateFrom { get; set; }

        [Required]
        public DateTime dateTo { get; set; }

        public string mccList { get; set; }
    }
}
