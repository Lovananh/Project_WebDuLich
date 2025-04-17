using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project_WebDuLich.Data;
using Project_WebDuLich.Models;

namespace Project_WebDuLich.Areas.Admin.Controllers
{
    public class AdminBookingController : Controller
    {
        private DatabaseTour db = new DatabaseTour();

        // GET: Admin/AdminBooking
        public ActionResult Index()
        {
            var bookings = db.bookings.Include(b => b.Tour).Include(b => b.User);
            return View(bookings.ToList());
        }

        // GET: Admin/AdminBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var booking = db.bookings
                            .Include(b => b.Tour)
                            .Include(b => b.User)
                            .FirstOrDefault(b => b.BookingID == id);

            if (booking == null) return HttpNotFound();

            return View(booking);
        }

        // GET: Admin/AdminBooking/UpdateStatus/5
        public ActionResult UpdateStatus(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var booking = db.bookings.Find(id);
            if (booking == null) return HttpNotFound();

            ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(Booking.BookingStatus)));
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int id, Booking.BookingStatus Status)
        {
            var booking = db.bookings.Find(id);
            if (booking == null) return HttpNotFound();

            booking.Status = Status;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
