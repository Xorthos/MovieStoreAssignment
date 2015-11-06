using System.Collections.Generic;
using System.Linq;
using MovieShopDALC.Context;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopDALC.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Add a customer and returns it
        /// </summary>
        public Customer Add(Customer cust)
        {

            using (var ctx = new MovieShopContext())
            {
                Customer newCust = ctx.Customers.Add(cust);
                ctx.SaveChanges();
                return newCust;
            }
        }

        /// <summary>
        /// List all customer
        /// </summary>
        /// <returns>a list containing all customers</returns>
        public IEnumerable<Customer> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customers.ToList();
            }
        }
        /// <summary>
        /// Returns a customer with a specified Email
        /// </summary>
        /// <param name="email">The email of the customer that is wanted</param>
        /// <returns></returns>

        public Customer Get(string email)
        {
            using (var ctx = new MovieShopContext())
            {
                var cust = ctx.Customers.Where(c => c.Email.Equals(email)).FirstOrDefault();
                return cust;
            }
        }

        /// <summary>
        /// returns a customers with a specified Id
        /// </summary>
        /// <param name="id">the Id of the Customer</param>
        /// <returns></returns>
        public Customer Get(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var cust = ctx.Customers.Where(c => c.Id == id).FirstOrDefault();
                return cust;
            }
        }
        /// <summary>
        /// Change a customer
        /// </summary>
        public Customer Update(Customer cust)
        {
            using (var ctx = new MovieShopContext())
            {
                var customer = ctx.Customers.Where(c => c.Id == cust.Id).FirstOrDefault();
                customer.FirstName = cust.FirstName;
                customer.MiddleName = cust.MiddleName;
                customer.LastName = cust.LastName;
                customer.StreetName = cust.StreetName;
                customer.StreetNumber = cust.StreetNumber;
                customer.Email = cust.Email;
                customer.Password = cust.Password;

                ctx.SaveChanges();
                return customer;
            }
        }

        public bool ChangeActive(Customer item)
        {
            throw new System.NotImplementedException();
        }
    }
}
