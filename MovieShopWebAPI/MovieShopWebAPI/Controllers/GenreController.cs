using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDALC.Facade;
using MovieShopDALC.Models;
using MovieShopDALC.Repositories.Abstraction;

namespace GenreShopWebAPI.Controllers
{
    public class GenreController : ApiController
    {
        //Gets the propper repository from the factory according to the object used.
        private IRepository<Genre> genreRepository = Facade.GetGenreRepository();


        public IEnumerable<Genre> GetGenres()
        {
            IEnumerable<Genre> Genres = genreRepository.GetAll();
            return Genres;
        }

        // GET: api/Genre/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre Genre = genreRepository.Get(id);
            if (Genre == null)
            {
                return NotFound();
            }

            return Ok(Genre);
        }

        // POST: api/Genre
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            genreRepository.Add(genre);

            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }
    }
}
