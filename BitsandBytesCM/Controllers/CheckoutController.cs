// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-06-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitsandBytesCM.Models;
using Microsoft.AspNet.Identity;

namespace BitsandBytesCM.Controllers
{
    /// <summary>
    /// Class CheckoutController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class CheckoutController : Controller
    {

        /// <summary>
        /// The application database
        /// </summary>
        ApplicationDbContext appDB = new ApplicationDbContext();

        // GET: Checkout
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Checkout/AddressAndPayment
        /// <summary>
        /// Checkouts the confirmation.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CheckoutConfirmation()
        {
                return View();
        }




        /* POST: /Checkout/CheckoutConfirmation
         * Try and change to Create order (Check product creation setup for code)
         * */
        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult CreateOrder()
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                    order.OrderTotal = ShoppingCart.GetCart(this.HttpContext).GetTotal();
                    order.OrderDate = DateTime.Now;
                    //var userId = User.Identity.GetUserId();
                    order.MemberId = User.Identity.GetUserId();


                //Save Order
                appDB.Orders.Add(order);
                    appDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        /// <summary>
        /// Completes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = appDB.Orders.Any(
                o => o.OrderId == id);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
        
    }
}