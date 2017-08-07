﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBYNew.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [ForeignKey("ContactTypeId")]
        public ContactType ContactType { get; set; }
        public int ContactTypeId { get; set; }

        private DateTime? JoinDate {get;set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
       
        public bool? IsSubscribedToNewsletter { get; set; }
    }
}