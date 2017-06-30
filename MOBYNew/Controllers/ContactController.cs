using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;

namespace MOBYNew.Controllers
{
    public class ContactController : Controller
    {

        // GET: Contact
        public ViewResult Index()

        {
            var contacts = GetContacts();

            { return View(contacts); }
        }

        //GET: Contact Detail view
        public ActionResult ContactDetail(int id)
        {
            var contactDetail = GetContacts().SingleOrDefault(c => c.Id == id);
            {
                if (contactDetail == null)
                    return HttpNotFound();

                return View(contactDetail);
            }
        }

        private IEnumerable<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact {Id=1, Name="Jackson" },
                new Contact {Id=2, Name= "Delmar" },
                new Models.Contact {Id= 3, Name= "Forsyth" },
                new Contact {Id = 4, Name= "Hanley" },
                new Contact {Id=5, Name= "Jeff" }

            };
        }
    }
}