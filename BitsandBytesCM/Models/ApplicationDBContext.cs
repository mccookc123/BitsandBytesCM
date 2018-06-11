// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-01-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    /// <summary>
    /// Class ApplicationDbContext.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{BitsandBytesCM.Models.User}" />
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public DbSet<Supplier> Suppliers { get; set; }
        /// <summary>
        /// Gets or sets the carts.
        /// </summary>
        /// <value>The carts.</value>
        public DbSet<Cart> Carts { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public DbSet<Order> Orders { get; set; }
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public DbSet<OrderDetail> OrderDetails { get; set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationDbContext.</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    /// <summary>
    /// Class DatabaseInitializer.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseAlways{BitsandBytesCM.Models.ApplicationDbContext}" />
    public class DatabaseInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    {


        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(ApplicationDbContext context)
        {


            context.Products.Add(new Product() { ProductDescription = "Test 1", ProductColour = "Red", ProductPrice = 32.99, CurrentStock = 50, lowestStockLimit = 25, }
                );

            

            if (!context.Users.Any())
            {

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var userStore = new UserStore<User>(context);


                if (!roleManager.RoleExists("ADMIN"))
                {
                    var roleresult = roleManager.Create(new IdentityRole("ADMIN"));
                }

                if (!roleManager.RoleExists("CUSTOMER"))
                {
                    var roleresult = roleManager.Create(new IdentityRole("CUSTOMER"));
                }

                if(!roleManager.RoleExists("STAFF"))
                {
                    var roleresult = roleManager.Create(new IdentityRole("STAFF"));
                }


                string userName = "admin@admin.com";
                string password = "123456";

                var user = userManager.FindByName(userName);
                if (user == null)
                {

                    var newUser = new Staff()
                    {
                        //FirstName = "Calum",
                        //LastName = "McCook",
                        //HouseNumber = 43,
                        //Street = "32 Cathedral Street",
                        //Town = "Glasgow",
                        //Postcode = "G1 2DJ",
                        UserName = userName,
                        Email = userName,
                        EmailConfirmed = true,
                        

                    };


                    userManager.Create(newUser, password);
                    userManager.AddToRole(newUser.Id, "ADMIN");
                }

                
                
            }


            base.Seed(context);
            context.SaveChanges();
        }

    }
}