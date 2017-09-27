using System.Collections.Generic;
using System.Linq;
using MOBYNew.Models;
using System.Web.Mvc;

namespace MOBYNew.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        private ApplicationDbContext _context;

        public ActionResult Index(string itemCategory, string searchString)
        {
            _context = new ApplicationDbContext();

            Invoice invoice = new Models.Invoice();

            var CategoryList = new List<string>();

            //var CategoryQuery = from i in _context.Items
            //                    orderby i.Category
            //                    select i.Category;

            var CategoryQuery = from c in _context.Categories
                                orderby c.CategoryName
                                select c.CategoryName;

            CategoryList.AddRange(CategoryQuery.Distinct());
            ViewBag.itemCategory = new SelectList(CategoryList);

            var items = from m in _context.Items
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.ItemName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(itemCategory))
            {
                items = items.Where(x => x.Category.ToString() == itemCategory);
            }

            return View(items);
        }

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
