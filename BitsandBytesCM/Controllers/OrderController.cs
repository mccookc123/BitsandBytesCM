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
    public class OrderController : Controller
    {

        private ApplicationDbContext _context;

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
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ViewOrders()
        {

            var orders = _context.Orders;

            return View(orders);

        }

        public ActionResult ViewOrderDetails(int id)
        {

            var orderDetails = _context.OrderDetails.Where(d => d.OrderId == id).Include(p => p.Product.ProductDescription);
            var products = _context.Products;
            List<string> productDescriptions;
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
            var viewModel = new OrderDetailsViewModel();


            viewModel.OrderDetails = orderDetails.Include(p => p.Product.ProductDescription).ToList();
            //viewModel.ProductDetails = 

            
               
            return View(viewModel);
        }

        //add in .where as users should onlhy be able to see their own orders.
        public ActionResult ViewOrdersMember()
        {

            var orders = _context.Orders;

            return View(orders);

        }

        public ActionResult ViewOrderDetailsMember(int id)
        {

            var orderDetails = _context.OrderDetails.Where(d => d.OrderId == id);




            return View(orderDetails);
        }

        public ActionResult EditOrders()
        {
            return View();
        }

        public ActionResult CancelOrders()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            Order order = _context.Orders.Find(id);
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("ViewOrders");

        }


    }
}