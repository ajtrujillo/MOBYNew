using System.ComponentModel.DataAnnotations;

namespace MOBYNew.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ContactTypeId { get; set; }

        public ContactTypeDto ContactType { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //public DateTime? JoinDate { get; set; } = DateTime.Now;

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //public DateTime? DOB { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
    }
}