using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.ViewModels;
using MOBYNew.Models;

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

        // GET: Contact
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CRUDOps))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            var contact = _context.Contacts
                .Include(c => c.ContactTypeName)
                .SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        // GET: Contact/Create
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Create()
        {
            var contactTypes = _context.ContactTypes.ToList();
            var viewModel = new ContactFormViewModel
            {
                Contact = new Contact(),
                ContactTypes = contactTypes
            };

            return View("ContactForm", viewModel);
        }

        //POST: Contact/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Save(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactFormViewModel
                {
                    Contact = contact,
                    ContactTypes = _context.ContactTypes.ToList()
                };

                return View("ContactForm", viewModel);
            }

            if (contact.Id == 0)
                _context.Contacts.Add(contact);

            else
            {
                var contactInDb = _context.Contacts.Single(c => c.Id == contact.Id);
                contactInDb.FirstName = contact.FirstName;
                contactInDb.LastName = contact.LastName;
                contactInDb.DOB = contact.DOB;
                contactInDb.ContactTypeId = contact.ContactTypeId;
                contactInDb.IsSubscribedToNewsletter = contact.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Contact");
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ContactTypeId,JoinDate,DOB,IsSubscribedToNewsletter")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Contacts.Add(contact);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "ContactTypeName", contact.ContactTypeId);
        //    return View(contact);
        //}
        // GET: Contact/Edit/5
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Edit(int? id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            var viewModel = new ContactFormViewModel
            {
                Contact = contact,
                ContactTypes = _context.ContactTypes.ToList()
            };

            return View("ContactForm", viewModel);
        }
    }
}

//        // POST: Contact/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ContactTypeId,JoinDate,DOB,IsSubscribedToNewsletter")] Contact contact)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(contact).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "ContactTypeName", contact.ContactTypeId);
//            return View(contact);
//        }

//        // GET: Contact/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Contact contact = db.Contacts.Find(id);
//            if (contact == null)
//            {
//                return HttpNotFound();
//            }
//            return View(contact);
//        }

//        // POST: Contact/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Contact contact = db.Contacts.Find(id);
//            db.Contacts.Remove(contact);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
