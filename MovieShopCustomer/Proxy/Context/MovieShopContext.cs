using Proxy.DomainModels;
using Proxy.Seeding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Context
{
    public class MovieShopContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Orderline> Orderline { get; set; }

        public MovieShopContext() : base("MovieShop")
        {
            Database.SetInitializer(new DBInitializer());
        }
    }
}
