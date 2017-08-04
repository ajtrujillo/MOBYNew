using System;
using System.ComponentModel.DataAnnotations;

namespace MOBYNew.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public ContactType ContactType { get; set; }
        public byte ContactTypeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }

        public bool? IsSubscribedToNewsletter { get; set; }
    }
}