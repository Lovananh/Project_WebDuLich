using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_WebDuLich.Models;

namespace Project_WebDuLich.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //ViewBag.Debug = $"Username: {model.Username}, Password: {model.Password}";
            // Kiểm tra đăng nhập đơn giản (có thể thay bằng DB)
            if (model.UserName == "admin" && model.PasswordHash == "123")
            {
                Session["Admin"] = model.UserName;
                return RedirectToAction("Index", "Admin");
            }
            else if (model.UserName.ToLower() == "user" && model.PasswordHash == "123")
            {
                Session["User"] = model.UserName;
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.Message = "Sai tên đăng nhập hoặc mật khẩu";
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}