using System;
using System.Web.Http;
using MOBYNew.Dtos;

namespace MOBYNew.Controllers.Api
{
    public class TransactionsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult NewTransaction(TransactionDto newTransaction)
        { throw new NotImplementedException(); }
    }
}
