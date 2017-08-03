using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class Discount
    {
        public byte Id { get; set; }
        public int discountPercent { get; set; }
        public int discountDuration { get; set; }
    }
}