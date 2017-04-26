using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BangazonOrientation.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProductName { get; set; }

        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal ProductPrice { get; set; }
    }
}