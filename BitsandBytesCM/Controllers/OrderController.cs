// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-11-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using BitsandBytesCM.Models;
using BitsandBytesCM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitsandBytesCM.Controllers
{
    /// <summary>
    /// Class OrderController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class OrderController : Controller
    {

        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }
        /*
        protected override void Dispose(bool disposing)
        {

            _context.Dispose();

        }*/
        // GET: Order
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Views the orders.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewOrders()
        {

            var orders = _context.Orders;

            return View(orders);

        }

        /// <summary>
        /// Views the order details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewOrderDetails(int id)
        {

            var orderDetails = _context.OrderDetails.Where(d => d.OrderId == id);
            //var products = _context.Products;
            //List<string> productDescriptions;
            //List<OrderDetail> productDescriptions = _context.OrderDetails.Where(d => d.OrderId == id).Select()
            /*
            foreach (var detail in orderDetails)
            {
                List<string> productList;
                foreach (var product in products)
                {
                    string productName;

                    if (product.ProductID == detail.ProductId)
                    {

                        productName = product.ProductDescription;
                    }

                    

                }
            }*/
            //Set up ViewModel
            //var viewModel = new OrderDetailsViewModel();


            //viewModel.OrderDetails = orderDetails.Include(p => p.Product.ProductDescription).ToList();
            //viewModel.ProductDetails = 

            
               
            return View(orderDetails);
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


        //add in .where as users should onlhy be able to see their own orders.
        /// <summary>
        /// Views the orders member.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewOrdersMember()
        {
            //Make it check for matching Id
            var orders = _context.Orders;

            return View(orders);

        }

        /// <summary>
        /// Views the order details member.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewOrderDetailsMember(int id)
        {

            var orderDetails = _context.OrderDetails.Where(d => d.OrderId == id);




            return View(orderDetails);
        }

        /// <summary>
        /// Edits the orders.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult EditOrders()
        {
            return View();
        }

        /// <summary>
        /// Cancels the orders.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CancelOrders()
        {
            return View();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int id)
        {
            Order order = _context.Orders.Find(id);
            return View(order);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("ViewOrders");

        }
        /*
        public ActionResult Edit(int id)
        {

            var orderDetails = _context.OrderDetails.SingleOrDefault(o => o.OrderDetailId == id);
            

            if (orderDetails == null)
                return HttpNotFound();

            var viewModel = new EditQuantityViewModel
            {
                OrderDetails = orderDetails

                
            };

            return View("Edit", viewModel);
        }


        public ActionResult EditQuantity(OrderDetail orderDetails)
        {
            //var product = _context.Products;
            var orderDetailsInDb = _context.OrderDetails.Single(m => m.OrderDetailId == orderDetails.OrderDetailId);
            orderDetailsInDb.Quantity = orderDetails.Quantity;

            var order = _context.Orders.SingleOrDefault(o => o.OrderId == orderDetails.OrderId);
            order.OrderTotal = orderDetails.Quantity * orderDetails.UnitPrice;

            


            //order.
            //Update order details price taking into account the quantity
            /*
            foreach(var orderDetail in orderDetails)
            {



            }
            
            _context.SaveChanges();

            return RedirectToAction("ViewOrders", "order");
        }
        */
    }
}