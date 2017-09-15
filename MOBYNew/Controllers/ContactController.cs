using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;
using MOBYNew.ViewModels;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Collections.Generic;

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

        //GET: Add Contact Form
        [HttpGet]
        public ActionResult AddContactGet()
        {
            var contactTypes = _context.ContactTypes.ToList();

            var viewmodel = new AddContactViewModel
            {
                ContactTypes = contactTypes
            };
            return View("AddContact", viewmodel);
        }

        //GET: Update Contact Form
        [HttpGet]
        public ActionResult UpdateContactGet(int id)
        {
            var contactTypes = _context.ContactTypes.ToList();

            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            var viewmodel = new UpdateContactViewModel
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DOB = contact.DOB,
                IsSubscribedToNewsletter = contact.IsSubscribedToNewsletter,
                ContactTypes = contactTypes
            };

            return View("UpdateContact", viewmodel);
        }


        [HttpPost]
        public ActionResult ContactPost(int? id)
        {
            var contactTypes = _context.ContactTypes.ToList();

            var contact = _context.Contacts.Single(x => x.Id == id);

            if (ModelState.IsValid)
            {
                var viewmodel = new UpdateContactViewModel
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    DOB = contact.DOB,
                    IsSubscribedToNewsletter = contact.IsSubscribedToNewsletter,
                    ContactTypes = contactTypes
                };

                return View("UpdateContact", viewmodel);
            }

            if (id != null)
                _context.Contacts.Add(contact);

            else
            {
                _context.Contacts.Add(new Contact
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    DOB = contact.DOB,
                    IsSubscribedToNewsletter = contact.IsSubscribedToNewsletter,
                    //TODO: Update the contact's Join Date
                    //JoinDate = DateTime.Now()
                });
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }

    }
}
