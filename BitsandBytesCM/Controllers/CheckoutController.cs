using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitsandBytesCM.Models;
using Microsoft.AspNet.Identity;

namespace BitsandBytesCM.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        
        ApplicationDbContext appDB = new ApplicationDbContext();
        
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult CheckoutConfirmation()
        {
                return View();
        }




        /* POST: /Checkout/CheckoutConfirmation
         * Try and change to Create order (Check product creation setup for code)
         * */
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