using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBYNew.Models
{
    public class ContactType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display (Name = "Contact Type")]
        public int Id { get; set; }

        [Display (Name ="Contact Type")]
        public string ContactTypeName { get; set; }

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