using mini_school_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mini_school_system.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> users = new List<User>();

        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists
                if (users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("", "Email is already registered.");
                    return View(model);
                }

                // Save the user
                users.Add(new User { Email = model.Email, Password = model.Password });

                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }


        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // On successful login, redirect to the home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }


        public ActionResult Logout()
        {
            // TODO: Implement session management or user state management
            return RedirectToAction("Login");
        }

    }
}