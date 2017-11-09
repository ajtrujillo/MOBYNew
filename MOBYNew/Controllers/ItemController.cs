using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MOBYNew.Models;

namespace MOBYNew.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemController
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.ItemCategory).Include(i => i.ItemGenre);

            if (User.IsInRole(RoleName.CRUDOps))
                return View(items.ToList());
            else
                return View("ReadOnlyList");
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ItemController/Create
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Create()
        {
            ViewBag.ItemCategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.ItemGenreId = new SelectList(db.Genres, "Id", "GenreName");
            return View();
        }

        // POST: ItemController/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Create([Bind(Include = "Id,ItemName,ReleaseDate,GenreId,CategoryId,ItemDescription,ImagePath,Price,ISBN13EAN,QtyInStock")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCategoryId = new SelectList(db.Categories, "Id", "CategoryName", item.ItemCategoryId);
            ViewBag.ItemGenreId = new SelectList(db.Genres, "Id", "GenreName", item.ItemGenreId);
            return View(item);
        }

        // GET: ItemController/Edit/5
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCategoryId = new SelectList(db.Categories, "Id", "CategoryName", item.ItemCategoryId);
            ViewBag.ItemGenreId = new SelectList(db.Genres, "Id", "genreName", item.ItemGenreId);
            return View(item);
        }

        // POST: ItemController/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Edit([Bind(Include = "Id,ItemName,ReleaseDate,GenreId,CategoryId,ItemDescription,ImagePath,Price,ISBN13EAN,QtyInStock")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCategoryId = new SelectList(db.Categories, "Id", "CategoryName", item.ItemCategoryId);
            ViewBag.ItemGenreId = new SelectList(db.Genres, "Id", "genreName", item.ItemGenreId);
            return View(item);
        }

        // GET: ItemController/Delete/5
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: ItemController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CRUDOps)]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
