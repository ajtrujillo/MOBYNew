using System.Collections.Generic;
using System.Web.Mvc;
using MOBYNew.Models;

namespace MOBYNew.Controllers
{
    public class ContactController : Controller
    {
       private List<Contact> contactList = new List<Contact>
            {
                new Contact {Name = "AJ", Id = 1},
                new Contact {Name = "Ben", Id = 2},
                new Contact {Name = "Jackson", Id = 3}
            };

        // GET: Contact
        public ActionResult Index()
        {
            return View(contactList);
        }

        public ActionResult ContactDetail(int id)
        {
            Contact tempContact = new Contact { Id = id };
            return View(tempContact);
        }
    }
}