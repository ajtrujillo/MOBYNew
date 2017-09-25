using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOBYNew.Models;
using System.Web.Mvc;

namespace MOBYNew.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            Invoice invoice = new Models.Invoice();
            return View(invoice);
        }

        //POST

        [HttpPost]
        public ActionResult AddItem(Invoice invoice)
        {
            invoice.Items.Add(invoice.NewItem);
            if (ModelState.IsValid)
            {
                return View("Index", invoice);
            }
            return View("Index", invoice);
        }
    }
}