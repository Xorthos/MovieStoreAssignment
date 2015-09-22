using Proxy.DomainModels;
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
        public DbSet<Movie> Items { get; set; }

        public MovieShopContext() : base("MovieShop")
        {

        }
    }
}
