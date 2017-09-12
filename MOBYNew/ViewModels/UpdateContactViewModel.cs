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
    }
}