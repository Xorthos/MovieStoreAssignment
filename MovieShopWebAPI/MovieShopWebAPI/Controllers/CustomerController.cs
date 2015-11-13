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
    public class CustomerController : ApiController
    {
        //Gets the propper repository from the factory according to the object used.
        private ICustomerRepository customerRepository = Facade.GetCustomerRepository();

        // GET: api/Customer
        /// <summary>
        /// this returns an IEnumerable, which contains all customers.
        /// </summary>
        /// <returns>an IEnumerable with customers</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        // GET: api/Customer/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = customerRepository.Get(id);
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
            Customer customer = customerRepository.Get(email);
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

            customerRepository.Update(customer);

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

            customerRepository.Add(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }
    }
}