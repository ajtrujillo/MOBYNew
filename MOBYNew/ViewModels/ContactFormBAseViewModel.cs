using MOBYNew.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MOBYNew.ViewModels
{
    public class ContactFormBaseViewModel
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        [Display(Name = "Join Date")]
        private DateTime JoinDate { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsletter { get; set; } = false;

        [Display(Name = "Type")]
        public ContactType contactType { get; set; }
        public int contactTypeId { get; set; }

        public IEnumerable<ContactType> ContactTypes { get; set; }
        public IEnumerable<ContactStatus> ContactStatus { get; set; }

    }
}