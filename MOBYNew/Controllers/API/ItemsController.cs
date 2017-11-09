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
    public class ItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/items
        public IHttpActionResult GetItems()
        {
            //return _context.Items.ToList().Select(Mapper.Map<Item, ItemDto>);
            var ItemDtos = _context.Items
                .Include(c => c.Category)
                .Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Item, ItemDto>);

            return Ok(ItemDtos);
        }

        // GET api/Items/5
        public IHttpActionResult GetItem(int id)
        {
            var Item = _context.Items.SingleOrDefault(c => c.Id == id);

            if (Item == null)
                return NotFound();

            return Ok(Mapper.Map<Item, ItemDto>(Item));
        }

        // POST api/Items
        [HttpPost]
        public IHttpActionResult CreateItem(ItemDto ItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Item = Mapper.Map<ItemDto, Item>(ItemDto);

            _context.Items.Add(Item);
            _context.SaveChanges();

            ItemDto.Id = Item.Id;

            return Created(new Uri(Request.RequestUri + "/" + Item.Id), ItemDto);
        }

        // PUT api/Items/5
        [HttpPut]
        public void UpdateItem(int id, ItemDto ItemDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ItemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (ItemInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<ItemDto, Item>(ItemDto, ItemInDb);

            _context.SaveChanges();
        }

        // DELETE api/Items/5
        [HttpDelete]
        public void DeleteItem(int id)
        {
            var ItemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (ItemInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Items.Remove(ItemInDb);
            _context.SaveChanges();
        }
    }
}