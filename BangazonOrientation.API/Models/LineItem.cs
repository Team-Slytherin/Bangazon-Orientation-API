using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonOrientation.API.Models
{
    public class LineItem
    {
        public int LineItemDetailId { get; set; }

        public int LineItemId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

    }
}