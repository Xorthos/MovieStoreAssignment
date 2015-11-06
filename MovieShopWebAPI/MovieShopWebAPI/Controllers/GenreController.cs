using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDALC.Facade;
using MovieShopDALC.Models;

namespace GenreShopWebAPI.Controllers
{
    public class GenreController : ApiController
    {
        private Facade facade = new Facade();


        public List<Genre> GetGenres()
        {
            List<Genre> Genres = facade.GetGenreRepository().GetAll();
            return Genres;
        }

        // GET: api/Genre/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre Genre = facade.GetGenreRepository().GetGenre(id);
            if (Genre == null)
            {
                return NotFound();
            }

            return Ok(Genre);
        }

        // POST: api/Genre
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre Genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            facade.GetGenreRepository().Add(Genre);

            return CreatedAtRoute("DefaultApi", new { id = Genre.Id }, Genre);
        }
    }
}
