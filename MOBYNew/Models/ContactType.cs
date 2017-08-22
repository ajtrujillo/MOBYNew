using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOBYNew.Models
{
    public class ContactType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string contactType { get; set; }

        public int? DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

        public bool? IsEligibleForDiscount { get; set; }

        public int? ContactStatusId { get; set; }
        [ForeignKey("ContactStatusId")]
        public ContactStatus ContactStatus { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

    }
}