using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.Context;
using Proxy.DomainModels;

namespace Proxy.Repositories
{
    public class GenreRepository : MovieRepository<Movie>
    {
        public override List<Movie> GetAll(MovieShopContext ctx)
        {
            return ctx.Movies.ToList();
        }
    }
}
