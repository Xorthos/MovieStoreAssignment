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
            //List<Movie> movies = facade.GetMovieRepository().getAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            //Movie.Genre = facade.GetMovieRepository().FindGenre(movie.Genre.Id);
            //facade.GetMovieRepository().AddGenre(movie);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int movieId) {

            //Movie = facade.GetMovieRepository().FindMovie(movieId),
            //Genre = facade.GetMovieRepository().GetGenre();
            
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            // movie.Genre = facade.GetMovieRepository().FindGenre(movie.Genre.Id);
            //facade.GetMovieRepository().UpdateMovie(movie);
            return Redirect("Index");

        }
        [HttpGet]
        public ActionResult Delete(int movieId)
        {
            return View(movieId);
        }
        [HttpPost]
        public ActionResult DeleteAccepted(int movieId)
        {
           // facade.GetMovieRepository().DeleteMovie(movieId);
            return Redirect("Index");
        }
    }
}