using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserTask.Models;

namespace UserTask.Controllers
{
    public class UserController : Controller
    {
        private UsersEntities db = new UsersEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register([Bind(Include = "UserEmail,UserPassword,ConfirmPassword")] User user)
        //{
        //    if (ModelState.IsValid && (user.ConfirmPassword == user.UserPassword))
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Login");
        //    }
        //    return View(user);
        //}

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include ="UserEmail, UserPassword, ConfirmPassword")] User user)
        {
            if(ModelState.IsValid && (user.ConfirmPassword == user.UserPassword))
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            {
                var r = db.Users.Where(model => model.UserEmail == user.UserEmail && model.UserPassword == user.UserPassword).FirstOrDefault();
                bool isValid = false;

                if (r != null)
                {
                    ViewBag.IsValid = true;
                    Session["Userid"] = r.UsersID;
                    return View("Index");
                }
            }

            return View();

        }

        //[HttpPost]
        //public ActionResult Login(User user)
        //{
        //    var r = db.Users.Where(model => model.UserEmail == user.UserEmail && model.UserPassword == user.UserPassword).FirstOrDefault();
        //    bool isValid = false;

        //    if (r != null)
        //    {
        //        ViewBag.isValid = true;
        //        Session["Userid"] = r.UsersID;
        //        return View("Index");
        //    }

        //    return View();
        //}

        public ActionResult Profile()
        {
            if (Session["Userid"] != null)
            {
                int userId = (int)Session["Userid"];
                var user = db.Users.Find(userId);
                return View(user);

            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(User user, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                user.UserImage = fileName;
            }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        public ActionResult ResetPassword()
        {
            var userID = (int)Session["Userid"];
            var user = db.Users.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            var userID = (int)Session["Userid"];
            var user = db.Users.Find(userID);

            if (currentPassword == user.UserPassword)
            {
                if (newPassword == confirmNewPassword)
                {
                    user.UserPassword = newPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Message = "New Password does not match Confirm Password!";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Message = "Current Password is incorrect!";
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session["Userid"] = null;
            return RedirectToAction("Index");
        }

    }
}