﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;

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

        public ViewResult Index()

        {
            var contacts = _context.Contacts.ToList();

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