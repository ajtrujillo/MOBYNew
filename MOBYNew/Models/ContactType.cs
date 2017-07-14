using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class ContactType
    {
        public byte Id { get; set; }
        public string contactType { get; set; }

        public Discount Discount { get; set; }
        public byte DiscountId { get; set; }
        public bool IsEligibleForDiscount { get; set; }

        public ContactStatus ContactStatus { get; set; }
        public byte ContactStatusId { get; set; }
    }
}