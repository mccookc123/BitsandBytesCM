using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class DatabaseInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    {


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