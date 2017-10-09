using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MOBYNew.Models;

namespace MOBYNew.Controllers.API
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context;
        
        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET api/contacts
        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }

        // GET api/contacts/5
        public Contact GetContact (int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return contact;
        }

        // POST api/contacts
        [HttpPost]
        public Contact CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        // PUT api/contacts/5
        [HttpPut]
        public void UpdateContact (int id, Contact contact)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            contactInDb.FirstName = contact.FirstName;
            contactInDb.LastName = contact.LastName;
            contactInDb.IsSubscribedToNewsletter = contact.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        // DELETE api/contacts/5
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();
        }
    }
}