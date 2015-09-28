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
                return ctx.Orders.Include("Customer").Include("Movie").ToList();
            }
        }

        public void ChangeOrder(Order ord)
        {
            using (var ctx = new MovieShopContext())
            {
                //gets the item that we want to update
                var order = ctx.Orders.Include("Customer").Include("Movie").Where(c => c.Id == ord.Id).FirstOrDefault();
                //changes the data
                order.Movie = ord.Movie;
                order.OrderDate = ord.OrderDate;
                order.Customer = ord.Customer;

                //saves the changes.
                ctx.SaveChanges();
            }
        }
    }
}
