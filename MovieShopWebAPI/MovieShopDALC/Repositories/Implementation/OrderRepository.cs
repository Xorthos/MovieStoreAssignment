using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDALC.Context;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopDALC.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Adds an order to the database and returns it.
        /// </summary>
        /// <param name="ord">the order to be added</param>
        public Order Add(Order ord)
        {

            using (var ctx = new MovieShopContext())
            {
                foreach (Orderline item in ord.Orderlines)
                {
                    bool isDetached = ctx.Entry(item.Movie).State == EntityState.Detached;
                    if (isDetached)
                        ctx.Movies.Attach(item.Movie);
                    ctx.Entry(item.Movie.Genre).State = EntityState.Detached;
                }
                GenreRepository genreRep = new GenreRepository();
                foreach (var item in genreRep.GetAll())
                {
                    ctx.Genres.Attach(item);
                }
                foreach (var item in ctx.Status.ToList())
                {
                    if (item.Name.Equals("Processing"))
                        ord.Status = item;
                }
                Order newOrd = ctx.Orders.Add(ord);
                ctx.SaveChanges();
                return newOrd;
            }

        }

        /// <summary>
        /// List all order
        /// </summary>
        /// <returns>a list containing all orders</returns>
        public IEnumerable<Order> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                var orderlines = ctx.Orderline.Include("Movie").ToList();
                var movies = ctx.Movies.Include("Genre").ToList();
                var orders = ctx.Orders.Include("Orderlines").Include("Status").ToList();

                foreach (var orderline in orderlines)
                {
                    orderline.Movie = movies.FirstOrDefault(cm => cm.Id == orderline.MovieId);
                }

                foreach (var item in orders)
                {
                    item.Orderlines = orderlines.Where(cm => cm.OrderId == item.Id).ToList();
                }

                return orders;
            }
        }

        public Order Get(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var orderlines = ctx.Orderline.Where(cm => cm.OrderId == id).Include("Movie").ToList();
                Order order =
                    ctx.Orders
                        .Include("Orderlines")
                        .Include("Status")
                        .FirstOrDefault(c => c.Id == id);

                order.Orderlines = orderlines;

                return order;
            }
        }

        /// <summary>
        /// Update one order 
        /// </summary>
        public Order Update(Order ord)
        {
            using (var ctx = new MovieShopContext())
            {
                //gets the item that we want to update
                var order = ctx.Orders.Include("Orderlines").Include("Status").FirstOrDefault(c => c.Id == ord.Id);
                //changes the data
                order.Orderlines = ord.Orderlines;
                order.OrderDate = ord.OrderDate;

                //saves the changes.
                ctx.SaveChanges();
                return order;
            }
        }

        public bool ChangeActive(Order item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// List all order by customer id
        /// </summary>
        public IEnumerable<Order> GetOrders(int id)
        {
            //this is dead, it was broken by Max, he changed shit
            using (var ctx = new MovieShopContext())
            {
                var orderlines = ctx.Orderline.Include("Movie").ToList();
                var orders = ctx.Orders.Include("Orderlines").Include("Status").Where(c => c.Id == id).ToList();

                foreach (var item in orders)
                {
                    item.Orderlines = orderlines.Where(cm => cm.OrderId == item.Id).ToList();
                }

                return orders;
            }

        }

        /// <summary>
        /// List all order by customer id
        /// </summary>
        public IEnumerable<Order> GetOrders(string username)
        {
            //this is dead, it was broken by Max, he changed shit
            using (var ctx = new MovieShopContext())
            {
                var orderlines = ctx.Orderline.Include("Movie").ToList();
                var orders = ctx.Orders.Include("Orderlines").Include("Status").Where(c => c.Email == username).ToList();

                foreach (var item in orders)
                {
                    item.Orderlines = orderlines.Where(cm => cm.OrderId == item.Id).ToList();
                }

                return orders;
            }

        }
    }
}
