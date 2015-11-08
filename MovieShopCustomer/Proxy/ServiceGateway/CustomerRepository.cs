using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxy.ServiceGateway
{
    public class CustomerRepository
    {
        protected static readonly string endPoint = Proxy.Proxy.GetBaseString() + "customer";
        /// <summary>
        /// Add a customer
        /// </summary>
        public void Add(Customer cust) {
            
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(endPoint, cust).Result;

            }
        }

        /// <summary>
        /// List all customer
        /// </summary>
        /// <returns>a list containing all customers</returns>
        public List<Customer> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint).Result;

                return JsonConvert.DeserializeObject<List<Customer>>(response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Returns a customer with a specified Email
        /// </summary>
        /// <param name="email">The email of the customer that is wanted</param>
        /// <returns></returns>
        
        public Customer GetCustomer(string email)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint + "?email=" + email).Result;

                return JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// returns a customers with a specified Id
        /// </summary>
        /// <param name="id">the Id of the Customer</param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint + "/" + id).Result;

                return JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Change a customer
        /// </summary>
        public void ChangeCustomer(Customer cust)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(endPoint, cust).Result;

            }
        }

        /// <summary>
        /// Change a password in the customer object
        /// </summary>
        public void ChangePassword(Customer cust)
        {
            
                var customer = GetAll().FirstOrDefault(c => c.Id == cust.Id);
                customer.Password = cust.Password;

                ChangeCustomer(customer);
            
        }
    }
}
