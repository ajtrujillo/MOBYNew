using System;

namespace MOBYNew.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ContactType ContactType { get; set; }
        public byte ContactTypeId { get; set; }

        public bool? IsSubscribedToNewsletter { get; set; }
    }
}