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
using MovieShopDALC.Factory;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        //Gets the propper repository from the factory according to the object used.
        private ICustomerRepository customeRepository = Factory.GetRepository(new Customer()) as ICustomerRepository;

        // GET: api/Customer
        public IEnumerable<Customer> GetCustomers()
        {
            return customeRepository.GetAll();
        }

        // GET: api/Customer/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = customeRepository.Get(id);
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
            Customer customer = customeRepository.Get(email);
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

            customeRepository.Update(customer);

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

            customeRepository.Add(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }
    }
}