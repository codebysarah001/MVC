using MiniShop3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniShop3.Controllers
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
        public ActionResult AddProduct(Product product)
        {
            List<Product> products = Session["Products"] as List<Product>;

            if (products == null)
            {
                products = new List<Product>();
            }


            products.Add(product);
            Session["Products"] = products;

            return RedirectToAction("AddProduct");
        }
    }
}