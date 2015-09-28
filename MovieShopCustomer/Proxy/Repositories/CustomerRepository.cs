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
                ctx.Customers.Add(cust);
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
                return ctx.Customers.ToList();
            }
        }
        /// <summary>
        /// Returns a customer with a specified Email
        /// </summary>
        /// <param name="email">The email of the customer that is wanted</param>
        /// <returns></returns>
        /*
        public Customer GetCustomer(string email)
        {
            using (var ctx = new MovieShopContext()) {
                 Customer cust = ctx.Customers.Select(c => c.Email);
                return cust;
            }
        }
        */
    }
}
