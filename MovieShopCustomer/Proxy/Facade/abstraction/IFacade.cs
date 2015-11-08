using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.DomainModels;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.Facade.abstraction
{
    public interface IFacade
    {
        ServiceGateway<Movie> GetMovieGateway();
        ServiceGateway<Genre> GetGenreGateway();
        ICustomerGateway GetCustomerGateway();
        IOrderGateway GetOrderGateway();

    }
}
