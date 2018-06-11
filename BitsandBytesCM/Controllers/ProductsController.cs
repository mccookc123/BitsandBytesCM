// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-10-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using BitsandBytesCM.Models;
using BitsandBytesCM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitsandBytesCM.Controllers
{
    /// <summary>
    /// Class ProductsController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ProductsController : Controller
    {

        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {

            _context.Dispose();

        }

        // GET: Products
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {

            var products = _context.Products;

            return View(products);
        }

        /// <summary>
        /// News this instance.
        /// </summary>
        /// <returns>ViewResult.</returns>
        public ViewResult New()
        {

            var viewModel = new ProductFormViewModel();

            return View("ProductForm", viewModel);

        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
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

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            var product = _context.Products.Single(p => p.ProductID == id);

            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        /// <summary>
        /// Saves the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>ActionResult.</returns>
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

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            return View(product);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        /// <summary>
        /// Modifies the product.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ModifyProduct()
        {

            var products = _context.Products;

            return View(products);
        }

    }
}