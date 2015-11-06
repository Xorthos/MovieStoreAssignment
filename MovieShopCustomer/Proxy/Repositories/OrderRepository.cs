
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proxy.Repositories
{
    public class OrderRepository
    {
        protected static readonly string endPoint = Proxy.Proxy.GetBaseString() + "order";
        /// <summary>
        /// Adds an order to the database
        /// </summary>
        /// <param name="ord">the order to be added</param>
        public void Add(Order ord)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(endPoint, ord).Result;

            }

        }

        /// <summary>
        /// List all order
        /// </summary>
        /// <returns>a list containing all orders</returns>
        public List<Order> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint).Result;

                return JsonConvert.DeserializeObject<List<Order>>(response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Update one order 
        /// </summary>
        public void ChangeOrder(Order ord)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(endPoint, ord).Result;

            }
        }

        /// <summary>
        /// List all order by customer id
        /// </summary>
        public List<Order> GetOrders(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint + "?custId=" + id).Result;

                return JsonConvert.DeserializeObject<List<Order>>(response.Content.ReadAsStringAsync().Result);
            }

        }
    }
}
