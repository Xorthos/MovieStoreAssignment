using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Proxy.Repositories
{
    public class MovieRepository
    {
        protected static readonly string endPoint = Proxy.Proxy.GetBaseString() + "movie";
        /// <summary>
        /// Add a movie
        /// </summary>
        public void Add(Movie movie)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PostAsJsonAsync(endPoint, movie).Result;

            }
        }
        /// <summary>
        /// Get all movie
        /// </summary>
        public List<Movie> GetAll()
        {
            return new List<Movie>();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint).Result;

                return JsonConvert.DeserializeObject<List<Movie>>(response.Content.ReadAsStringAsync().Result);
            }

        }

        /// <summary>
        /// returns the movie by Id
        /// </summary>
        /// <returns>the movie with the given Id</returns>
        public Movie GetMovie(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(endPoint + "/" + id).Result;

                return JsonConvert.DeserializeObject<Movie>(response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Delete a movie
        /// </summary>
        public void Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.DeleteAsync(endPoint + "/" + id).Result;
            }
        }
        /// <summary>
        /// Update a movie
        /// </summary>
        public void UpdateMovie(Movie mov)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(endPoint,mov).Result;

            }
        }
    }
}
