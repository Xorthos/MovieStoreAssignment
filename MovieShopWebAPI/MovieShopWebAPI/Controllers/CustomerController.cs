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
    public class CustomerController : ApiController
    {
        private Facade facade = new Facade();

        // GET: api/Customer
        public List<Customer> GetCustomers()
        {
            return facade.GetCustomerRepository().GetAll();
        }

        // GET: api/Customer/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = facade.GetCustomerRepository().GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET: api/Customer/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(string email)
        {
            Customer customer = facade.GetCustomerRepository().GetCustomer(email);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            facade.GetCustomerRepository().UpdateCustomer(customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customer
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            facade.GetCustomerRepository().Add(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }
    }
}