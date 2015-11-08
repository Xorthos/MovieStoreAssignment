using Proxy.DomainModels;
using Proxy.Facade.abstraction;
using Proxy.ServiceGateway.Abstraction;
using Proxy.ServiceGateway.Implementation;

namespace Proxy.Facade.Implementation
{
    public class Facade : IFacade
    {
        /// <summary>
        /// Creates a MovieGateway and returns it
        /// </summary>
        /// <returns>a movie Gateway</returns>
        public ServiceGateway<Movie> GetMovieGateway()
        {
            return new MovieGateway();
        }

        /// <summary>
        /// Creates a GenreGateway and returns it
        /// </summary>
        /// <returns>A genre Gateway</returns>
        public ServiceGateway<Genre> GetGenreGateway()
        {
            return new GenreGateway();
        }

        /// <summary>
        /// Creates a CustomerGateway
        /// </summary>
        /// <returns>a Customer Gateway</returns>
        public ICustomerGateway GetCustomerGateway()
        {
            return new CustomerGateway();
        }

        /// <summary>
        /// Creates a Ordergateway
        /// </summary>
        /// <returns>a Order gateway</returns>
        public IOrderGateway GetOrderGateway()
        {
            return new OrderGateway();
        }
    }
}
