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
    public class ShoppingCartController : Controller
    {

        ApplicationDbContext appDB = new ApplicationDbContext();

        

        // GET: ShoppingCart
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


        public ActionResult Delete(int id)
        {
            Cart cart = appDB.Carts.Find(id);
            return View(cart);
        }

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
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}