﻿using BitsandBytesCM.Models;
using BitsandBytesCM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitsandBytesCM.Controllers
{
    public class ProductsController : Controller
    {

        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {

            _context.Dispose();

        }

        // GET: Products
        public ActionResult Index()
        {

            var products = _context.Products;

            return View(products);
        }

        public ViewResult New()
        {

            var viewModel = new ProductFormViewModel();

            return View("ProductForm", viewModel);

        }

        public ActionResult Edit(int id)
        {

            var product = _context.Products.SingleOrDefault(c => c.ProductID == id);


            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                Product = product
            };

            return View("ProductForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Single(p => p.ProductID == id);

            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(m => m.ProductID == product.ProductID);
                productInDb.ProductDescription = product.ProductDescription;
                productInDb.ProductColour = product.ProductColour;
                productInDb.ProductPrice = product.ProductPrice;
                productInDb.CurrentStock = product.CurrentStock;
                productInDb.lowestStockLimit = product.lowestStockLimit;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ModifyProduct()
        {

            var products = _context.Products;

            return View(products);
        }

    }
}