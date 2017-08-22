using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;
using MOBYNew.ViewModels;

namespace MOBYNew.Controllers
{
    public class ContactController : Controller
    {

        // GET: Contact
        private ApplicationDbContext _context;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult AddContactGet(Contact contact, AddContactViewModel viewModel)
        {
            var contactTypes = _context.ContactTypes.ToList();
            {
                //ContactTypes = contactTypes;
                //contact.FirstName = viewModel.FirstName;
                //contact.LastName = viewModel.LastName;
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddContactPost(AddContactViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        //GET: Contact List View
        public ViewResult Index()
        {
            var contacts = _context.Contacts.Include(c => c.ContactType).ToList();
            return View(contacts);
        }

        //GET: Contact Detail view
        public ActionResult ContactDetail(int id)
        {
            var contactDetail = _context.Contacts.SingleOrDefault(c => c.Id == id);
            {
                if (contactDetail == null)
                    return HttpNotFound();

                return View(contactDetail);
            }
        }


    }
}