using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{
    public class MovieRepository
    {

        public void Add(Movie movie)
        {
            using(var ctx = new MovieShopContext())
            {
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
            }
        }

        public List<Movie> GetAll()
        {
            using(var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genre").ToList();
            }
        }
    }
}
