using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;
using MOBYNew.ViewModels;
using AutoMapper;

namespace MOBYNew.Controllers
{
    public class ContactController : Controller
    {

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
        public ActionResult AddContactGet()//Contact contact, AddContactViewModel viewModel)
        {
            var contactTypes = _context.ContactTypes.ToList();
            var viewmodel = new AddContactViewModel
            {
                ContactTypes = contactTypes
                //contact.FirstName = viewModel.FirstName;
                //contact.LastName = viewModel.LastName;
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContactPost(AddContactViewModel viewmodel)
        {
            _context.Contacts.Add(viewmodel);

            var createContactModel = _context.Contacts.Find(AddContactViewModel.Id);
            AddContactViewModel dto = Mapper.Map<AddContactViewModel>(Contact);

            if (ModelState.IsValid)
                //    {
                //        _context.Contacts.Add(new Contact
                //        {
                //            FirstName = this.
                //        });
                //        _context.SaveChanges();
                //        return RedirectToAction("Index");
                //    }

                return View(createContactModel);
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