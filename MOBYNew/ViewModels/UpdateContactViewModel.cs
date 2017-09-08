using MOBYNew.Models;
using MOBYNew.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOBYNew.ViewModels
{
    public class UpdateContactViewModel : ContactFormBaseViewModel
    {
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }

        //[Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Last Name is Required")]
        //public string LastName { get; set; }

        //[Display(Name = "Date of Birth")]
        //public DateTime? DOB { get; set; }

        //public bool IsSubscribedToNewsletter { get; set; } = false;

        //[Display(Name = "Type")]
        //public ContactType contactType { get; set; }
        //public int contactTypeId { get; set; }

        //public IEnumerable<ContactType> ContactTypes { get; set; }

    }
}