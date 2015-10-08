using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{
    public class CustomerRepository
    {
        public void Add(Customer cust) {

            using(var ctx = new MovieShopContext())
            {
                ctx.Customer.Add(cust);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a list containing all customers</returns>
        public List<Customer> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Customer.ToList();
            }
        }
        /// <summary>
        /// Returns a customer with a specified Email
        /// </summary>
        /// <param name="email">The email of the customer that is wanted</param>
        /// <returns></returns>
        
        public Customer GetCustomer(string email)
        {
            using (var ctx = new MovieShopContext()) {
                 var cust = ctx.Customers.Where(c => c.Email.Equals(email)).FirstOrDefault();
                return cust;
            }
        }

        /// <summary>
        /// returns a customers with a specified Id
        /// </summary>
        /// <param name="id">the Id of the Customer</param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var cust = ctx.Customer.Where(c => c.Id == id).FirstOrDefault();
                return cust;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ChangeCustomer(Customer cust)
        {
            using (var ctx = new MovieShopContext())
            {
                var customer = ctx.Customer.Include("Genre").Where(c => c.Id == cust.Id).FirstOrDefault();
                customer.FirstName = cust.FirstName;
                customer.StreetName = cust.StreetName;
                customer.StreetNumber = cust.StreetNumber;
                customer.Email = cust.Email;
                customer.LastName = cust.LastName;

                ctx.SaveChanges();
            }
        }
    }
}
