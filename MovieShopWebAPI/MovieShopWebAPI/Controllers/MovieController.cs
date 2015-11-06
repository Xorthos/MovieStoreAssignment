using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDALC.Context;
using MovieShopDALC.Facade;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace MovieShopWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        //Gets the propper repository from the factory according to the object used.
        private IRepository<Movie> movieRepository = Facade.GetMovieRepository();


        public IEnumerable<Movie> GetMovies()
        {
            IEnumerable<Movie> movies = movieRepository.GetAll();
            return movies;

        }

        // GET: api/Movie/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = movieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            movieRepository.Update(movie);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movie
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            movieRepository.Add(movie);

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }
    }
}