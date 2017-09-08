﻿using System.Data.Entity;
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
        public ActionResult UpdateContactGet()
        {
            var contactTypes = _context.ContactTypes.ToList();
            var viewmodel = new UpdateContactViewModel
            {
                ContactTypes = contactTypes
            };
            return View("UpdateContact", viewmodel);
        }

        //GET: Contact Edit view
        //public ActionResult EditContact(int id)
        //{
        //    var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

        //    if (contact == null)
        //        return HttpNotFound();

        //    var viewModel = new UpdateContactViewModel
        //    {
        //        FirstName = contact.FirstName,
        //        LastName = contact.LastName,
        //        DOB = contact.DOB,
        //        IsSubscribedToNewsletter = contact.IsSubscribedToNewsletter,
        //        ContactTypes = _context.ContactTypes.ToList()
        //    };

        //    return View("EditContact", viewModel);
        //}

        //[HttpPost]
        //public ActionResult AddContactPost(UpdateContactViewModel viewmodel, int contactTypeId)
        //{
        //    ApplicationDbContext _addContactContext = new ApplicationDbContext();

        //    if (ModelState.IsValid)
        //    {
        //        _context.Contacts.Add(new Contact
        //        {
        //            ContactTypeId = viewmodel.contactTypeId,
        //            FirstName = viewmodel.FirstName,
        //            LastName = viewmodel.LastName,
        //            DOB = viewmodel.DOB,
        //            IsSubscribedToNewsletter = viewmodel.IsSubscribedToNewsletter
        //        });

        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Contact");
        //    }

        //    return View(viewmodel);
        //}

        [HttpPost]
        public ActionResult ContactPost(ContactFormBaseViewModel viewmodel, int? id)
        {
            if (ModelState.IsValid)
            {
                var context = new ApplicationDbContext();
                if (id != null)
                //{
                //    if (context.Contacts.Any(x => x.Id == id))
                {
                    var updateContact = from contact in context.Contacts
                                        where contact.Id == id
                                        select contact;

                    foreach (Contact contactAttribute in updateContact)
                    {
                        contactAttribute.FirstName = viewmodel.FirstName;
                        contactAttribute.LastName = viewmodel.LastName;
                        contactAttribute.DOB = viewmodel.DOB;
                        contactAttribute.IsSubscribedToNewsletter = viewmodel.IsSubscribedToNewsletter;
                        contactAttribute.ContactType = viewmodel.contactType;
                    }
                }

                else
                {
                    _context.Contacts.Add(new Contact
                    {
                        ContactTypeId = viewmodel.contactTypeId,
                        FirstName = viewmodel.FirstName,
                        LastName = viewmodel.LastName,
                        DOB = viewmodel.DOB,
                        IsSubscribedToNewsletter = viewmodel.IsSubscribedToNewsletter
                    });
                }

                _context.SaveChanges();
                return RedirectToAction("Index", "Contact");
            }
            return View(viewmodel);

        }
    }
}