using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDALC.Context;
using MovieShopDALC.Models;
using MovieShopDALC.Facade;

namespace MovieShopWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        private Facade facade = new Facade();

        
        public List<Movie> GetMovies()
        {
            List<Movie> movies = (List<Movie>)facade.GetMovieRepository().GetAll();
            return movies;
        }

        // GET: api/Movie/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = facade.GetMovieRepository().GetMovie(id);
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

            facade.GetMovieRepository().UpdateMovie(movie);

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

            facade.GetMovieRepository().Add(movie);

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }
    }
}