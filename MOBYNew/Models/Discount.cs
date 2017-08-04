using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string discountName { get; set; }
        public int? discountPercent { get; set; }
        public int? discountDurationInMonths { get; set; }
    }
}