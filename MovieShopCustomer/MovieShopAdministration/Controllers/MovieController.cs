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
            //MAYBE THE NAME OF THE REPOSITORY IS GOING TO CHANGE!!
            List<Genre> genres = facade.GetGenreRepository().GetAll();

            return View(genres);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            //METHOD NAME MIGHT CHANGE.
            //Movie.Genre = facade.GetGenreRepository().FindGenre(movie.Genre.Id);
            //facade.GetMovieRepository().AddMovie(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int movieId) {

            //Movie theMovie = facade.GetMovieRepository().GetMovie(movieId);
            List<Genre> genres = facade.GetGenreRepository().GetAll();
            //EditMovieModel theViewModel = new EditMovieModel() { Movie = theMovie, Genres = genres };
            
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            //METHOD NAME MIGHT CHANGE.
            //movie.Genre = facade.GetGenreRepository().FindGenre(movie.Genre.Id);
            //METHOD NAME MIGHT CHANGE.
            //facade.GetMovieRepository().UpdateMovie(movie);
            return Redirect("Index");

        }
        [HttpGet]
        public ActionResult Delete(int movieId)
        {
            //Movie theMovie = facade.GetMovieRepository().FindMovie(movieId);
            return View();
        }
        [HttpPost]
        public ActionResult DeleteAccepted(int movieId)
        {
            //facade.GetMovieRepository().DeleteMovie(movieId);
            return Redirect("Index");
        }
    }
}