using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BitsandBytesCM.Models
{
    public partial class ShoppingCart
    {

        ApplicationDbContext appDB = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";


        protected void Dispose(bool disposing)
        {
            appDB.Dispose();
        }

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        //Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            //Get the matching cart and product instances
            var cartItem = appDB.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == product.ProductID);

            if (cartItem == null)
            {
                //Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ProductId = product.ProductID,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                appDB.Carts.Add(cartItem);


            }
            else
            {
                //If the item does exist in the cart,
                //then add one to the quantity
                //Possibly need to edit at a later point
                cartItem.Count++;



            }
            appDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {

            var cartItem = appDB.Carts.Single(cart => cart.CartId == ShoppingCartId && cart.Id == id);

            int itemCount = 0;

            if (cartItem != null)
            {

                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    appDB.Carts.Remove(cartItem);
                }

                //Save changes
                appDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {

            var cartItems = appDB.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                appDB.Carts.Remove(cartItem);
            }

            // Save changes
            appDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {

            var cart = appDB.Carts.ToList();

            var cartToReturn = new List<Cart>();

            foreach(Cart c in cart)
            {
                if(c.CartId == ShoppingCartId)
                {
                    c.Product = appDB.Products.FirstOrDefault(p => p.ProductID == c.ProductId);
                    cartToReturn.Add(c);
                }
            }


            return cartToReturn;
        }
        
        /*public Product GetProduct(int id)
        {

            

            return 

        }
        */
        public int GetCount()
        {
            //Get the count of each item in the cart and sum them up
            int? count = (from cartItems in appDB.Carts where cartItems.CartId == ShoppingCartId select (int?)cartItems.Count).Sum();

            //Return 0 if all enteries are null
            return count ?? 0;
        }
        public double GetTotal()
        {
            //Multiply album price by count lof that album to get
            //the current price for each of those albums in the cart
            //sum all album price totals to get the cart total
            double? total = (from cartItems in appDB.Carts where cartItems.CartId == ShoppingCartId select (double?)cartItems.Count * cartItems.Product.ProductPrice).Sum();

            return total ?? 0.0;
        }
        public int CreateOrder(Order order)
        {
            double orderTotal = 0.0;

            var cartItems = GetCartItems();
            //Iterate over the items in the cart,
            //adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.ProductPrice,
                    Quantity = item.Count
                };

                //Set the order total of the shopping cart
                orderTotal += (item.Count * item.Product.ProductPrice);
                appDB.OrderDetails.Add(orderDetail);

            }

            //Set the order's total to the orderTotal count
            order.OrderTotal = orderTotal;

            //Save the order
            appDB.SaveChanges();
            //Empty the shopping cart
            EmptyCart();
            //Return the OrderId as the confirmation number
            return order.OrderId;
        }

        //We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {

            if(context.Session[CartSessionKey] == null)
            {
                //consider keeping original code and modifying User to automatically create full name
                if (!string.IsNullOrWhiteSpace(context.User.Identity.GetUserId()))
                {

                    context.Session[CartSessionKey] = context.User.Identity.GetUserId();


                }
                else
                {
                    //Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    //Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();

                }
            }
            return context.Session[CartSessionKey].ToString();

        }

        //When a user has logged in, migrate their shopping cart to
        //be associated with their username
        public void MigrateCart(string username)
        {

            var shoppingCart = appDB.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = username;
            }
            appDB.SaveChanges();

        }





    }
}