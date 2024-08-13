using MiniProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject2.Controllers
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
        public ActionResult AddProduct(Products product)
        {
            List<Products> products = Session["Products"] as List<Products>;

            if (products == null)
            {
                products = new List<Products>();
            }


            products.Add(product);
            Session["Products"] = products;

            return RedirectToAction("AddProduct");
        }
    }
}