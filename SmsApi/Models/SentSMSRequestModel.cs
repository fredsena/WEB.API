using System;
using System.ComponentModel.DataAnnotations;

namespace SmsApi.Models
{
    public class SentSMSRequestModel
    {
        [Required]
        public DateTimeOffset dateTimeFrom { get; set; }

        [Required]
        public DateTimeOffset dateTimeTo { get; set; }

        [Required]
        public int skip { get; set; }

        [Required]
        public int take { get; set; }
    }
}