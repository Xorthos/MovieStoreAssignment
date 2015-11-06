using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDALC.Models;

namespace MovieShopDALC.Repositories.Abstraction
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Get(string email);
    }
}
