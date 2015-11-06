using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDALC.Context;
using MovieShopDALC.Facade;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        //Gets the propper repository from the factory according to the object used.
        private IOrderRepository orderRepository = Facade.GetOrderRepository();

        // GET: api/Order
        public IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> orders = orderRepository.GetAll();
            return orders;
        }

        // GET: api/Order
        public IEnumerable<Order> GetUserOrders(int custId)
        {
            return orderRepository.GetOrders(custId);
        }

        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            orderRepository.Update(order);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Order
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            orderRepository.Add(order);

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }
    }
}