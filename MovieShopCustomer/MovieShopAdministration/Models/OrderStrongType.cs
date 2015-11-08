using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proxy.Facade.Implementation;

namespace MovieShopAdministration.Models
{
    public class OrderStrongType
    {

        public List<Order> Orders { get; set; }

        //These are only to allow strong typing
        public Customer Customer { get; private set; }

        public Orderline Orderline { get; private set; }

        public Order Order { get; private set; }
        // to here

        /// <summary>
        /// Constructor: sets the orders.
        /// </summary>
        public OrderStrongType()
        {
            Orders = new Facade().GetOrderRepository().GetAll();
        }
    }
}