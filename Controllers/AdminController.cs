using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project_WebDuLich.Data;
using Project_WebDuLich.Models;

namespace Project_WebDuLich.Areas.Admin.Controllers
{
    public class AdminToursController : Controller
    {
        private DatabaseTour db = new DatabaseTour();

        // GET: Admin/AdminTours
        public ActionResult Index()
        {
            return View(db.tours.ToList());
        }

        // GET: Admin/AdminTours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTours/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tours tour)
        {
            if (ModelState.IsValid)
            {
                db.tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Admin/AdminTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tour = db.tours.Find(id);
            if (tour == null) return HttpNotFound();

            return View(tour);
        }

        // POST: Admin/AdminTours/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tours tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Admin/AdminTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var tour = db.tours.Find(id);
            if (tour == null) return HttpNotFound();

            return View(tour);
        }

        // POST: Admin/AdminTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tour = db.tours.Find(id);
            db.tours.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
