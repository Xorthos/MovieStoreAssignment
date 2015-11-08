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
    class GenreGateway : ServiceGateway<Genre>
    {
        protected static readonly string GENRE_END_POINT = END_POINT + "Genre/";
        /// <summary>
        /// Adds a genre to the database
        /// </summary>
        /// <param name="gen">the genre to be added</param>
        public override Genre Add(Genre item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(GENRE_END_POINT, item).Result;

                return JsonConvert.DeserializeObject<Genre>(result.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Get all genre
        /// </summary>
        /// <returns>a list containing all genres</returns>
        public override IEnumerable<Genre> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(GENRE_END_POINT).Result;

                return JsonConvert.DeserializeObject<List<Genre>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// gets a specific genre
        /// </summary>
        /// <param name="id">the Id of the wanted genre</param>
        /// <returns>the wanted genre</returns>
        public override Genre Get(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(GENRE_END_POINT + id).Result;

                return JsonConvert.DeserializeObject<Genre>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Will update the given genre in the database
        /// </summary>
        /// <param name="item">The genre that is wanted updated</param>
        /// <returns>true if the genre was updated</returns>
        public override bool Update(Genre item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(GENRE_END_POINT, item).Result;
                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public override void Deactivate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
