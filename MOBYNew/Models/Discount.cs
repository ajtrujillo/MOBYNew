using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class Discount
    {
        public Discount()
        { }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string discountName { get; set; }
        public int? discountPercent { get; set; }
        public int? discountDurationInMonths { get; set; }
    }
}