using MovieShopDALC.Models;
using MovieShopDALC.Seeding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Status> status { get; set; }

        public MovieShopContext() : base("Data Source=80.167.187.177;Integrated Security=False;User ID=Mads;Password=ipaeeea8;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=MovieShop")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
