using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ShopController : Controller
    {
        private static List<Product> products
             = new List<Product>()
             {
                 new Product{Code="X001", Description="Cup", Price=0.89},
                 new Product{Code="X002", Description="Plate", Price=2.43},
                 new Product{Code="X025", Description="Tesla Model X", Price=100000.89}
             };

        private static ShoppingCart cart = new ShoppingCart();

        // GET: Shop
        public ActionResult Index()
        {
            ViewBag.Total = cart.CalculateTotalPrice();
            return View(products);
        }

        public ActionResult Add(string code)
        {
            try
            {
                foreach(var item in products)
                {
                    if (item.Code == code)
                    {
                        cart.AddItem(item);
                        break;
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
            
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
