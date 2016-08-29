using System.ComponentModel.DataAnnotations;

namespace SmsApi.Models
{
    public class SendSmsRequestModel
    {
        [Required]
        [RegularExpression("^[+]?([0-9]){10,20}$", ErrorMessage = "Invalid from number: (+ Country code | mobile CC | phone number)")]
        public string from { get; set; }

        [Required]
        [RegularExpression("^[+]?([0-9]){10,20}$", ErrorMessage = "Invalid from number: (+ Country code | mobile CC | phone number)")]
        public string to { get; set; }

        [Required]        
        public string text { get; set; }
    }
}