using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
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
        public IEnumerable<ContactDto> GetContacts()
        {
            return _context.Contacts.ToList().Select(Mapper.Map<Contact, ContactDto>);
        }

        // GET api/contacts/5
        public IHttpActionResult GetContact(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound();

            return Ok (Mapper.Map<Contact, ContactDto>(contact));
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
        public void UpdateContact(int id, ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<ContactDto, Contact>(contactDto, contactInDb);

            _context.SaveChanges();
        }

        // DELETE api/contacts/5
        [HttpDelete]
        public void DeleteContact(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();
        }
    }
}