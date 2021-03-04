using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalmetal.Models
{
    public class product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="enter product name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="enter product price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="upload product image")]
        public string Image1 { get; set; }
        [Required(ErrorMessage = "upload product image")]
        public string Image2 { get; set; }

        [Required(ErrorMessage = "upload product image")]
        public string Image3 { get; set; }


    }
}