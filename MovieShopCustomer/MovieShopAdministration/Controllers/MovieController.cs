using MovieShopAdministration.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopAdministration.Controllers
{
    public class MovieController : Controller
    {
        Facade facade = new Facade();
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = facade.GetMovieRepository().GetAll();

            return View(movies);
        }

        [HttpGet]
        public ActionResult Create() {

            EditMovieModel genre = new EditMovieModel();
            return View(genre);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            //METHOD NAME MIGHT CHANGE.
            movie.Genre = facade.GetGenreRepository().GetGenre(movie.Genre.Id);
            facade.GetMovieRepository().Add(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int movieId) {

            Movie theMovie = facade.GetMovieRepository().GetMovie(movieId);
            List<Genre> genres = facade.GetGenreRepository().GetAll();
            EditMovieModel theViewModel = new EditMovieModel() { Movie = theMovie, Genres = genres };
            
            return View(theViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
                //METHOD NAME MIGHT CHANGE.
                movie.Genre = facade.GetGenreRepository().GetGenre(movie.Genre.Id);
            //METHOD NAME MIGHT CHANGE.
            facade.GetMovieRepository().UpdateMovie(movie);
            return Redirect("Index");

        }
        [HttpGet]
        public ActionResult Delete(int movieId)
        {
            Movie theMovie = facade.GetMovieRepository().GetMovie(movieId);
            return View(theMovie);
        }
        [HttpPost]
        public ActionResult DeleteAccepted(int movieId)
        {
            facade.GetMovieRepository().Delete(movieId);
            return Redirect("Index");
        }
    }
}