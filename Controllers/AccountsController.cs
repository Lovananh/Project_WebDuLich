using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_WebDuLich.Models;
using Project_WebDuLich.Models.ViewModel;

namespace Project_WebDuLich.Controllers
{
    public class AccountsController : Controller
    {
        private DatabaseTours db = new DatabaseTours();

        // GET: /Account/Register
        public ActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.users.Any(u => u.UserName == model.UserName))
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View(model);
                }

                var user = new User { UserName = model.UserName, PasswordHash = model.PasswordHash };
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: /Account/Login
        //public ActionResult Login() => View();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = db.users.FirstOrDefault(u => u.UserName == model.UserName && u.PasswordHash == model.PasswordHash);
            if (user != null)
            {
                Session["UserId"] = user.UserID;
                Session["Username"] = user.UserName;
                Session["Role"] = user.Role;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid credentials");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}