using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MOBYNew.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBYNew.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int ContactTypeId { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //public DateTime? JoinDate { get; set; } = DateTime.Now;

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
    }
}