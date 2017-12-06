using System.Linq;
using System.Net;
using System;
using System.Data.Entity;
using System.Web.Http;
using MOBYNew.Models;
using MOBYNew.DTOs;
using AutoMapper;

namespace MOBYNew.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/contacts
        public IHttpActionResult GetContacts(string query = null)
        {
            var contactsQuery = _context.Contacts
                .Include(c => c.ContactTypeName);

            if (!String.IsNullOrWhiteSpace(query))
                contactsQuery = contactsQuery.Where(c => c.LastName.Contains(query));

            var contactDtos = contactsQuery
                .ToList()
                .Select(Mapper.Map<Contact, ContactDto>);
            //var contactDtos = _context.Contacts
            //    .Include(c => c.ContactTypeName)
            //    .ToList()
            //    .Select(Mapper.Map<Contact, ContactDto>);

            //return Ok(contactDtos);
            return Ok(contactDtos);
        }

        // GET api/contacts/5
        public IHttpActionResult GetContact(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound();

            return Ok(Mapper.Map<Contact, ContactDto>(contact));
        }

        // POST api/contacts
        [HttpPost]
        public IHttpActionResult CreateContact(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contact = Mapper.Map<ContactDto, Contact>(contactDto);

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            contactDto.Id = contact.Id;

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contactDto);
        }

        // PUT api/contacts/5
        [HttpPut]
        public IHttpActionResult UpdateContact(int id, ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                return NotFound();

            Mapper.Map(contactDto, contactInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/contacts/5
        [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                return NotFound();

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}