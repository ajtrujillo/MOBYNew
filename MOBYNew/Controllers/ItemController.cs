using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;

namespace MOBYNew.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _context;

        public ItemController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //attribute route with constraints
        //[Route("item/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}/{day:regex(\\d{2}):range(1,31)}")]
        //public ActionResult ByReleaseDate(int year, int month, int? day)
        //{
        //    return Content(year + "/" + month + "/" + day);
        //}

        //// item
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue) pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

        //    return Content(String.Format("pageIndex = {0}&sortBy={1}", pageIndex, sortBy));
        //}     
        public ViewResult Index()
        {
            var items = _context.Items.Include(i => i.Genre).ToList();

            return View(items);

        }

        public ActionResult itemDetail(int id)
        {
            var item = _context.Items.Include(i => i.Genre).SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

    }
}