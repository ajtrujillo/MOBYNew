using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBYNew.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display (Name = "Contact Type")]
        [ForeignKey("ContactTypeId")]
        public ContactType ContactTypeName { get; set; }
        public int ContactTypeId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? JoinDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public virtual IEnumerable<ContactType> contactTypes { get; set; }
        public virtual IEnumerable<Discount> discounts { get; set; }

    }
}