using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDALC.Context;
using MovieShopDALC.Models;
using MovieShopDALC.Facade;

namespace MovieShopWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        private Facade facade = new Facade();

        // GET: api/Order
        public List<Order> GetOrders()
        {
            List<Order> orders = facade.GetOrderRepository().GetAll();
            return orders;
        }

        // GET: api/Order
        public List<Order> GetUserOrders(int custId)
        {
            return facade.GetOrderRepository().GetOrders(custId);
        }

        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            facade.GetOrderRepository().ChangeOrder(order);

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

            facade.GetOrderRepository().Add(order);

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }
    }
}