using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;
using MOBYNew.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace MOBYNew.Controllers
{
    public class ContactController : Controller
    {

        private ApplicationDbContext _context;
        //private List<ContactType> ContactTypes;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult AddContactGet()
        {
            var contactTypes = _context.ContactTypes.ToList();
            var viewmodel = new AddContactViewModel
            {
                ContactTypes = contactTypes
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddContactPost(AddContactViewModel viewmodel, int contactTypeId)
        {
            ApplicationDbContext _testdb = new ApplicationDbContext();
            Contact dataModelContact = _testdb.Contacts.Where(c => c.ContactTypeId == contactTypeId).First();

            if (ModelState.IsValid)
            {
                _context.Contacts.Add(new Contact
                {
                    ContactTypeId = viewmodel.contactTypeId,
                    FirstName = viewmodel.FirstName,
                    LastName = viewmodel.LastName,
                    DOB = viewmodel.DOB,
                    IsSubscribedToNewsletter = viewmodel.IsSubscribedToNewsletter
                });
                _context.SaveChanges();
                return RedirectToAction("Index", "Contact");
            }

            return View(viewmodel);
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