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
    public class OrderGateway : IOrderGateway
    {
        protected static readonly string ORDER_END_POINT = END_POINT + "Order/";

        /// <summary>
        /// sends an order to the web api, that will then be added to the Database
        /// </summary>
        /// <param name="item">the order to be added</param>
        /// <returns>The order with the correct primary key</returns>
        public override Order Add(Order item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(ORDER_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<Order>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public override IEnumerable<Order> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(ORDER_END_POINT).Result;

                return JsonConvert.DeserializeObject<List<Order>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Not implemented yet, Don't use
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Order Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool Update(Order item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(ORDER_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Not implemented yet, Don't use
        /// </summary>
        /// <param name="id"></param>
        public override void Deactivate(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Order> GetOrders(int customerId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(END_POINT + "Order?custId=" + customerId).Result;

                return JsonConvert.DeserializeObject<List<Order>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public override IEnumerable<Order> GetOrders(string username)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(END_POINT + "Order?username=" + username).Result;

                return JsonConvert.DeserializeObject<List<Order>>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
