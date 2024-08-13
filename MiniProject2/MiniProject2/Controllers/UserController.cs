using MiniProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            List<Products> products = Session["Products"] as List<Products>;

            if (products == null)
            {
                products = new List<Products>();
            }

            return View(products);

        }
    }
}