using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonOrientation.API.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public int CustomerId { get; set; }

        public int PaymentId { get; set; }

        public string Active { get; set; }
    }
}