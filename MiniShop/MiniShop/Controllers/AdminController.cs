using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string ProductName, decimal Price, string ProductImage)
        {
            List<Dictionary<string, string>> products = Session["Products"] as List<Dictionary<string, string>>;
            
            if (products == null)
            {
                products = new List<Dictionary<string, string>>();

            }

            Dictionary<string, string> product = new Dictionary<string, string>
            {
                {"Name",ProductName},
                {"Price", Price.ToString()},
                {"Image",ProductImage}
            };

            products.Add(product);
            Session["Products"] = products;

            return RedirectToAction("AddProduct");
        }

    }
}