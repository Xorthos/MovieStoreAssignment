using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Repositories.Implementation;

namespace MovieShopDALC.Facade
{
    public class Facade
    {
        //Hack to make sure that the DLL file for EntityFramework.SQLserver is being included in the build.
        private System.Data.Entity.SqlServer.SqlProviderServices ensureDLLIsCopied =
            System.Data.Entity.SqlServer.SqlProviderServices.Instance;

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
    }
}
