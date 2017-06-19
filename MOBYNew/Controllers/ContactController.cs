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
            List<Contact> contactList = new List<Contact>
            {
                new Contact {Name = "AJ", Id = 1},
                new Contact {Name = "Ben", Id = 2},
                new Contact {Name = "Jackson", Id = 3}
            };

            return View(contactList);
        }
    }
}