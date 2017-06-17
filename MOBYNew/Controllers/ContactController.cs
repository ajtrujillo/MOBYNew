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
            List<Contact> contactList = new List<Contact>();

            {
                new Contact { Name = "Amy", Id = 1 };
                new Contact { Name = "Ben", Id = 2 };
                //List<Contact> contactsList = new List<Contact>
                //{
                //    new Contact {Name = "Amy", Id = 1},
                //    new Contact {Name = "Dan", Id = 2},

                //};

                //return View(contactsList);

                //var contacts = new List<Contact>
                //{
                //    new Contact() {Name = "Contact 1", Id=1},
                //    new Contact() {Name = "Contact 2", Id=2}
                //};

                //var contactViewModel = new ContactViewModel();

                //return View(contactViewModel);
            }

            return View(contactList);
        }
    }
}