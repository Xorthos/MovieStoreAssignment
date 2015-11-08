using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proxy.DomainModels;
using Proxy.ServiceGateway.Abstraction;

namespace Proxy.ServiceGateway.Implementation
{
    public class CustomerGateway: ICustomerGateway
    {
        //Constant, the address of the web api
        protected static readonly string CUSTOMER_END_POINT = END_POINT + "Customer/";

        /// <summary>
        /// sends a cutomer that will then be added to the database.
        /// </summary>
        /// <param name="item">the customer to be added</param>
        /// <returns>the customer with the correct primary key.</returns>
        public override Customer Add(Customer item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(CUSTOMER_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<Customer>(result.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// List all customer
        /// </summary>
        /// <returns>a list containing all customers</returns>
        public override IEnumerable<Customer> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(CUSTOMER_END_POINT).Result;

                return JsonConvert.DeserializeObject<List<Customer>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Gets a specific customer
        /// </summary>
        /// <param name="id">the id of the wanted customer</param>
        /// <returns>the wanted customer</returns>
        public override Customer Get(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(CUSTOMER_END_POINT + id).Result;

                return JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Sends a customer to the webapi which is then in turn updated
        /// </summary>
        /// <param name="item">The customer that is wanted updated</param>
        /// <returns>true if the customer was successfully updated</returns>
        public override bool Update(Customer item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(CUSTOMER_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// not implemented yet, Don't use.
        /// </summary>
        /// <param name="id"></param>
        public override void Deactivate(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a customer with the email.
        /// </summary>
        /// <param name="email">the email of the wanted customer</param>
        /// <returns>the wanted customer.</returns>
        public override Customer Get(string email)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(END_POINT + "Customer?email=" + email).Result;

                return JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
