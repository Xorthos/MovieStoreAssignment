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
    public class MovieGateway : ServiceGateway<Movie>
    {
        // remember that the END_POINT is inheirited from the ServiceGateway
        protected static readonly string MOVIE_END_POINT = END_POINT + "Movie/";
        

        /// <summary>
        /// Sends a post request to the webapi, which will create the Movie in the database
        /// </summary>
        /// <param name="item">The movie that is going to be added to the database.</param>
        /// <returns>The movie with the real primary key.</returns>
        public override Movie Add(Movie item)
        {
            using (var httpClient = new HttpClient())
            {
                //this sends of a post method.
                var result = httpClient.PostAsJsonAsync(MOVIE_END_POINT, item).Result;
                //because the web api is supposed to send back the added movie, we get that result here.
                return JsonConvert.DeserializeObject<Movie>(result.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Sends a get request to the webapi, which will return an IEnumerable of Movies
        /// </summary>
        /// <returns>An IEnumerable of Movies.</returns>
        public override IEnumerable<Movie> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(MOVIE_END_POINT).Result;

                return JsonConvert.DeserializeObject<List<Movie>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Sends a get request to the database, to return a specific movie
        /// </summary>
        /// <param name="id">The id of the movie that is wanted</param>
        /// <returns>The movie that was requested</returns>
        public override Movie Get(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(MOVIE_END_POINT + id).Result;
                var mov = JsonConvert.DeserializeObject<Movie>(response.Content.ReadAsStringAsync().Result);

                return mov;
            }
        }

        /// <summary>
        /// Updates the movie in the database.
        /// </summary>
        /// <param name="item">the movie that will be changed in the database</param>
        /// <returns>true, if the movie was updated</returns>
        public override bool Update(Movie item)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.PutAsJsonAsync(MOVIE_END_POINT, item).Result;
                return JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Not implemented yet. Don't use. also hello!
        /// </summary>
        /// <param name="id"></param>
        public override void Deactivate(int id)
        {
            throw new NotImplementedException();
        }
    }
}
