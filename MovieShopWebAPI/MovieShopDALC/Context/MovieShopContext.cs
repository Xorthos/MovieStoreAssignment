using MovieShopDALC.Models;
using MovieShopDALC.Seeding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;

namespace MovieShopDALC.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MovieShopContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Orderline> Orderline { get; set; }
        public DbSet<Status> Status { get; set; }


        public MovieShopContext() : base("name=db")
        {
            //Configuration.ProxyCreationEnabled = false;

            //I'm going to turn off lazy loading instead.
            //Lazy loading is a problem when we start serialising therefore I now turn it off, I also removed the XML formatter.
            Configuration.LazyLoadingEnabled = false;
        }
    }
}
