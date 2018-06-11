// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-04-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using BitsandBytesCM.Models;
using BitsandBytesCM.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitsandBytesCM.Controllers
{
    /// <summary>
    /// Class ShoppingCartController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ShoppingCartController : Controller
    {

        /// <summary>
        /// The application database
        /// </summary>
        ApplicationDbContext appDB = new ApplicationDbContext();



        // GET: ShoppingCart
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);

            //Set up ViewModel
            var viewModel = new ShoppingCartViewModel();

            
            viewModel.CartItems = cart.GetCartItems();
            viewModel.CartTotal = cart.GetTotal();
            
            //Return the view
            return View(viewModel);

        }

        /// <summary>
        /// Adds to cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult AddToCart(int id)
        {
            //Retrieve the Product from the database
            var addedProduct = appDB.Products.Single(product => product.ProductID == id);

            //Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

            //Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int id)
        {
            Cart cart = appDB.Carts.Find(id);
            return View(cart);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = appDB.Carts.Find(id);
            appDB.Carts.Remove(cart);
            appDB.SaveChanges();
            return RedirectToAction("Index");

        }

        /*[HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            //Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            //Get the name of the Product to display confirmation
            string productName = appDB.Carts.Single(item => item.Id == id).Product.ProductDescription;

            //Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            //Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id

            };

            return Json(results);
        }
        */
        /// <summary>
        /// Carts the summary.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}