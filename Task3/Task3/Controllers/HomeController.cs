using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        private const string validUsername = "user";
        private const string validPassword = "password";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }

        [HttpPost]
        public ActionResult LoginInfo(string username, string password)
        {
            if (username == validUsername && password == validPassword)
            {
                // Save user info in session
                Session["Username"] = username;
                Session["Password"] = password;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid username or password.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult SubmitContactForm(string Name, string PhoneNumber, string Gender, string Country, string[] Interests)
        {
            ViewBag.Name = Name;
            ViewBag.PhoneNumber = PhoneNumber;
            ViewBag.Gender = Gender;
            ViewBag.Country = Country;
            ViewBag.Interests = Interests;

            return View("Contact");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}