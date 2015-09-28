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
                 var cust = ctx.Customers.Where(c => c.Email == email).FirstOrDefault();
                return cust;
            }
        }
<<<<<<< HEAD
        */
=======

        /// <summary>
        /// returns a customers with a specified Id
        /// </summary>
        /// <param name="id">the Id of the Customer</param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                var cust = ctx.Customers.Where(c => c.Id == id).FirstOrDefault();
                return cust;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ChangeMovie(Customer cust)
        {
            using (var ctx = new MovieShopContext())
            {
                var customer = ctx.Customers.Include("Genre").Where(c => c.Id == cust.Id).FirstOrDefault();
                customer.FirstName = cust.FirstName;
                customer.Address = cust.Address;
                customer.Email = cust.Email;
                customer.LastName = cust.LastName;

                ctx.SaveChanges();
            }
        }
>>>>>>> 37bf7ec2e10742534b88cbb153bb519cf8e71402
    }
}
