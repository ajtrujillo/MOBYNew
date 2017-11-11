using MOBYNew.Models;
using System.Collections.Generic;

namespace MOBYNew.ViewModels
{
    public class ContactFormViewModel
    {
        public IEnumerable<ContactType> ContactTypes { get; set; }
        public Contact Contact { get; set; }
    }
}