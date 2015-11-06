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

    public class MovieShopContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Orderline> Orderline { get; set; }
        public DbSet<Status> Status { get; set; }

        public MovieShopContext() : base("name=MyContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
