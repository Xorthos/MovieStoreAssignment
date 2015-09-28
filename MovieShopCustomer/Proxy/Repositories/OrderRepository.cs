using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{
    public class OrderRepository
    {
        /// <summary>
        /// Adds a genre to the database
        /// </summary>
        /// <param name="ord">the order to be added</param>
        public void Add(Order ord)
        {

            using (var ctx = new MovieShopContext())
            {
                ctx.Orders.Add(ord);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list containing all orders</returns>
        public List<Order> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Orders.ToList();
            }
        }
    }
}
