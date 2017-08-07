using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class Discount
    {
        public Discount()
        { }

        [Key]
        public int Id { get; set; }
        public string discountName { get; set; }
        public int? discountPercent { get; set; }
        public int? discountDurationInMonths { get; set; }
    }
}