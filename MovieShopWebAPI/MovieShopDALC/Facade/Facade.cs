
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;
using MovieShopDALC.Repositories.Implementation;

namespace MovieShopDALC.Facade
{
    public static class Facade
    {
        public static IRepository<Movie> GetMovieRepository()
        {
            return new MovieRepository();
        }

        public static IRepository<Genre> GetGenreRepository()
        {
            return new GenreRepository();
        }

        public static ICustomerRepository GetCustomerRepository()
        {
            return new CustomerRepository();
        }

        public static IOrderRepository GetOrderRepository()
        {
            return new OrderRepository();
        }
        //public static IRepository<Object> GetRepository(Object t)
        //{
        //    if(t is Movie)
        //    {
        //        return new MovieRepository() as IRepository<Object>;
        //    }
        //    if (t is Genre)
        //    {
        //        return new GenreRepository() as IRepository<Object>;
        //    }
        //    if (t is Customer)
        //    {
        //        return new CustomerRepository() as IRepository<Object>;
        //    }
        //    if (t is Order)
        //    {
        //        return new OrderRepository() as IRepository<Object>;
        //    }
        //        return null;
        //}
    }
}
