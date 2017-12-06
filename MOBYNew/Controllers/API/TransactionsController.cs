using System;
using System.Web.Http;
using MOBYNew.Dtos;
using MOBYNew.Models;
using System.Linq;

namespace MOBYNew.Controllers.Api
{
    public class TransactionsController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult NewTransaction(TransactionDto newTransaction)
        {
            var contact = _context.Contacts.Single(c => c.Id == newTransaction.ContactId);

            var items = _context.Items.Where(m => newTransaction.ItemIds.Contains(m.Id)).ToList();

            foreach (var item in items)
            {
                if (item.QtyInStock == 0)
                    return BadRequest("This item is out of stock");

                item.QtyInStock--;

                var transaction = new Transaction
                {
                    TRNContact = contact,
                    TRNItem = item,
                    TRNDate = DateTime.Now
                };

                _context.Transactions.Add(transaction);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
