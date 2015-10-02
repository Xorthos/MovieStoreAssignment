using Proxy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Facade
{
    public class Facade
    {
        /// <summary>
        /// Creates a Movierepository and returns it
        /// </summary>
        /// <returns>a movie repository</returns>
        public MovieRepository GetMovieRepository()
        {
            return new MovieRepository();
        }

        /// <summary>
        /// Creates a GenreRepository and returns it
        /// </summary>
        /// <returns>A genre repository</returns>
        public GenreRepository GetGenreRepository()
        {
            return new GenreRepository();
        }
        
        /// <summary>
        /// Creates a CustomerRepository
        /// </summary>
        /// <returns>a Customer repository</returns>
        public CustomerRepository GetCustomerRepository()
        {
            return new CustomerRepository();
        }

        /// <summary>
        /// Creates a orderrepository
        /// </summary>
        /// <returns>a Order repository</returns>
        public OrderRepository GetOrderRepository()
        {
            return new OrderRepository();
        }

        /// <summary>
        /// Creates a shoppingcartrepository
        /// </summary>
        /// <returns>a shoppingcart repository</returns>
        public ShoppingCartRepository GetShoppingCartRepository()
        {
            return new ShoppingCartRepository();
        }
    }
}
