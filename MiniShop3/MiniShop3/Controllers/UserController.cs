using MiniShop3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniShop3.Controllers
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
            List<Product> products = Session["Products"] as List<Product>;

            if (products == null)
            {
                products = new List<Product>();
            }

            return View(products);

        }
    }
}