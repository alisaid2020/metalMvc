using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalmetal.Models
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="enter  user name")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="enter email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }


    }
}