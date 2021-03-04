using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalmetal.Models
{
    public class gmail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "enter Our Email ")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email")]
        public string To { get; set; }

        [Required(ErrorMessage = "enter your email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter Valid Email")]
        public string From { get; set; }
        
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "your Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}