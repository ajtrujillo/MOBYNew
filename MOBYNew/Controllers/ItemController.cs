using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MOBYNew.Models;
using MOBYNew.ViewModels;

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

        // GET: ItemController
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CRUDOps))
                return View("List");
            else
                return View("ReadOnlyList");
        }

        // GET: ItemController/Create
        [Authorize(Roles = RoleName.CRUDOps)]
        public ViewResult Create()
        {
            var genres = _context.Genres.ToList();
            var categories = _context.Categories.ToList();

            var viewModel = new ItemFormViewModel
            {
                Genres = genres,
                Categories = categories
            };

            return View("ItemForm", viewModel);
        }

        // GET: ItemController/Edit/5
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Edit(int? id)
        {
            var item = _context.Items.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return HttpNotFound();

            var viewModel = new ItemFormViewModel(item)
            {
                Genres = _context.Genres.ToList(),
                Categories = _context.Categories.ToList()
            };

            return View("ItemForm", viewModel);
        }


        // GET: ItemController/Details/5
        public ActionResult Details(int? id)
        {
            var item = _context.Items
                .Include(m => m.ItemGenre).SingleOrDefault(m => m.Id == id);
                //.Include(m => m.ItemCategory).SingleOrDefault(m => m.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        //// GET: ItemController/Delete/5
        //[Authorize(Roles = RoleName.CRUDOps)]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = _context.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// POST: ItemController/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = RoleName.CRUDOps)]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Item item = _context.Items.Find(id);
        //    _context.Items.Remove(item);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //// GET: Items/Random
        //public ActionResult Random()
        //{
        //    var item = new Item() { Name = "Shrek!" };
        //    var contacts = new List<Contacts>
        //     {
        //         new Contact { Name = "Contact 1" },
        //         new Contact { Name = "Contact 2" }
        //     };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Item = item,
        //        Contact = contact
        //    };

        //    return View(viewModel);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Save(Item item)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ItemFormViewModel(item)
                {
                    Genres = _context.Genres.ToList(),
                    Categories = _context.Categories.ToList()
                };

                return View("ItemForm", viewModel);
            }

            if (item.Id == 0)
            {
                item.DateAdded = DateTime.Now;
                _context.Items.Add(item);
            }
            else
            {
                var itemInDb = _context.Items.Single(m => m.Id == item.Id);
                itemInDb.ItemName = item.ItemName;
                itemInDb.ItemGenreId = item.ItemGenreId;
                itemInDb.ItemCategoryId = item.ItemCategoryId;
                itemInDb.QtyInStock = item.QtyInStock;
                itemInDb.ReleaseDate = item.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Item");
        }
    }
}
