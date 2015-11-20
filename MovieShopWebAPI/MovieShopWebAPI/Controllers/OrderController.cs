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
        public HttpResponseMessage GetOrders()
        {
            IEnumerable<Order> orders = orderRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }

        // GET: api/Order
        public HttpResponseMessage GetUserOrders(int custId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, orderRepository.GetOrders(custId));
        }

        // GET: api/Order
        public IEnumerable<Order> GetUserOrders(string username)
        {
            return orderRepository.GetOrders(username);
        }

        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Order newOrder = orderRepository.Update(order);

            return Request.CreateResponse(HttpStatusCode.OK, newOrder);
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