﻿using Proxy.Context;
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
        /// <summary>
        /// Add a customer
        /// </summary>
        public void Add(Customer cust) {

            using(var ctx = new MovieShopContext())
            {
                ctx.Customers.Add(cust);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// List all customer
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
                var cust = ctx.Customers.Where(c => c.Id == id).FirstOrDefault();
                return cust;
            }
        }
        /// <summary>
        /// Change a customer
        /// </summary>
        public void ChangeCustomer(Customer cust)
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

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Change a password in the customer object
        /// </summary>
        public void ChangePassword(Customer cust)
        {
            using (var ctx = new MovieShopContext())
            {
                var customer = ctx.Customers.Where(c => c.Id == cust.Id).FirstOrDefault();
                customer.Password = cust.Password;

                ctx.SaveChanges();
            }
        }
    }
}
