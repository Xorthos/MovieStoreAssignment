
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;
using MovieShopDALC.Repositories.Implementation;

namespace MovieShopDALC.Factory
{
    public static class Factory
    {
        public static IRepository<Object> GetRepository(Object t)
        {
            if(t is Movie)
            {
                return new MovieRepository() as IRepository<Object>;
            }
            if (t is Genre)
            {
                return new GenreRepository() as IRepository<Object>;
            }
            if (t is Customer)
            {
                return new CustomerRepository() as IRepository<Object>;
            }
            if (t is Order)
            {
                return new OrderRepository() as IRepository<Object>;
            }
                return null;
        }
    }
}
