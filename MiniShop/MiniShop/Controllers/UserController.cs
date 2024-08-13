using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniShop.Controllers
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
            List<Dictionary<string, string>> products = Session["Products"] as List<Dictionary<string, string>>;

            if (products == null)
            {
                products = new List<Dictionary<string, string>>();

            }
            return View(products);

        }
    }
}