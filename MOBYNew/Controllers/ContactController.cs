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
                new Contact {Id=1, FirstName="Jackson", LastName="Trujillo" },
                new Contact {Id=2, FirstName= "Delmar", LastName="Trujillo" },
                new Models.Contact {Id= 3, FirstName= "Forsyth", LastName="Trujillo" },
                new Contact {Id = 4, FirstName= "Hanley", LastName="Trujillo" },
                new Contact {Id=5, FirstName= "Jeff", LastName="Trujillo" }

            };
        }
    }
}