using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOBYNew.Models;
using MOBYNew.ViewModels;

namespace MOBYNew.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var contacts = new List<Contact>
            {
                new Contact() {Name = "Contact 1"},
                new Contact() {Name = "Contact 2"}
            };

            var contactViewModel = new ContactViewModel();

            return View(contactViewModel);
        }
    }
}