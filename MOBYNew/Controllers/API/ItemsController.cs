using System.Linq;
using System.Net;
using System;
using System.Data.Entity;
using System.Web.Http;
using MOBYNew.Models;
using MOBYNew.DTOs;
using AutoMapper;
using System.Collections.Generic;

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
        public IEnumerable<ItemDto> GetItems(string query= null)
        {
            var itemsQuery = _context.Items
                .Include(m => m.ItemCategory)
                .Where(m => m.QtyInStock > 0);

            if (!String.IsNullOrWhiteSpace(query))
                itemsQuery = itemsQuery.Where(m => m.ItemName.Contains(query));

            return itemsQuery
                .ToList()
                .Select(Mapper.Map<Item, ItemDto>);
            //return _context.Items
            //    .Include(c => c.ItemCategory)
            //    .Include(c => c.ItemGenre)
            //    .ToList()
            //    .Select(Mapper.Map<Item, ItemDto>);
        }

        // GET api/Items/5
        public IHttpActionResult GetItem(int id)
        {
            var item = _context.Items.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<Item, ItemDto>(item));
        }

        // POST api/Items
        [HttpPost]
        [Authorize(Roles = RoleName.CRUDOps)]
        public IHttpActionResult CreateItem(ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var item = Mapper.Map<ItemDto, Item>(itemDto);

            _context.Items.Add(item);
            _context.SaveChanges();

            itemDto.Id = item.Id;
            return Created(new Uri(Request.RequestUri + "/" + item.Id), itemDto);
        }

        // PUT api/Items/5
        [HttpPut]
        [Authorize(Roles = RoleName.CRUDOps)]
        public IHttpActionResult UpdateItem(int id, ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var itemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                return NotFound();

            Mapper.Map<ItemDto, Item>(itemDto, itemInDb);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/Items/5
        [HttpDelete]
        [Authorize(Roles = RoleName.CRUDOps)]
        public IHttpActionResult DeleteItem(int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (itemInDb == null)
                return NotFound();

            _context.Items.Remove(itemInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}