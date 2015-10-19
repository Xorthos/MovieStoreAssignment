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
                var g = ctx.Orders.Add(ord);
                foreach (var item in ord.Orderlines)
                {
                    item.OrderId = g.Id;
                }
                ctx.Orderline.AddRange(ord.Orderlines);
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
                var orderlines = ctx.Orderline.Include("Movie").ToList();
                var orders = ctx.Orders.Include("Customer").Include("Orderlines").Include("Status").ToList();

                foreach (var item in orders)
                {
                    item.Orderlines = orderlines.Where(cm => cm.OrderId == item.Id).ToList();
                }

                return orders;
            }
        }

        public void ChangeOrder(Order ord)
        {
            using (var ctx = new MovieShopContext())
            {
                //gets the item that we want to update
                var order = ctx.Orders.Include("Customer").Include("Orderlines").Include("Status").Where(c => c.Id == ord.Id).FirstOrDefault();
                //changes the data
                order.Orderlines = ord.Orderlines;
                order.OrderDate = ord.OrderDate;
                order.Customer = ord.Customer;

                //saves the changes.
                ctx.SaveChanges();
            }
        }

        public List<Order> GetOrders(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var orderlines = ctx.Orderline.Include("Movie").ToList();
                var orders = ctx.Orders.Include("Customer").Include("Orderlines").Include("Status").Where(c => c.Customer.Id == id).ToList();

                foreach (var item in orders)
                {
                    item.Orderlines = orderlines.Where(cm => cm.OrderId == item.Id).ToList();
                }

                return orders;
            }

        }
    }
}
