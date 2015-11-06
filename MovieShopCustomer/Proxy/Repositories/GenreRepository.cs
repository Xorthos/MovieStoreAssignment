using Proxy.DomainModels;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Proxy.Repositories
{
    public class GenreRepository
    {
        protected static readonly string endPoint = Proxy.Proxy.GetBaseString() + "genre";
        /// <summary>
        /// Adds a genre to the database
        /// </summary>
        /// <param name="gen">the genre to be added</param>
        public void Add(Genre gen)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(endPoint, gen).Result;

            }
        }
        
        /// <summary>
        /// Get all genre
        /// </summary>
        /// <returns>a list containing all genres</returns>
        
        public List<Genre> GetAll()
        {
            return new List<Genre>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint).Result;

                return JsonConvert.DeserializeObject<List<Genre>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        ///Edit one genre 
        /// </summary>
        public void EditGenre(Genre gen)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(endPoint, gen).Result;

            }
        }
        /// <summary>
        /// Get one genre by id
        /// </summary>
        public Genre GetGenre(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint + "/" + id).Result;

                return JsonConvert.DeserializeObject<Genre>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
