using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proxy.DomainModels;

namespace Proxy.ServiceGateway.Abstraction
{
    public abstract class IOrderGateway : ServiceGateway<Order>
    {
        public abstract IEnumerable<Order> GetOrders(int customerId);
    }
}
