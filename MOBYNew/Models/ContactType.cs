using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class ContactType
    {
        public int Id { get; set; }
        public string contactType { get; set; }

        public Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public bool? IsEligibleForDiscount { get; set; }

        public ContactStatus ContactStatus { get; set; }
        public int ContactStatusId { get; set; }
    }
}