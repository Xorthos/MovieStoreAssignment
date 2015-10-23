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
            List<Genre> genres = facade.GetGenreRepository().GetAll();

            return View(new IndexViewModel() { Movies = movies, Genres = genres });
        }

        [HttpGet]
        public ActionResult FilterMovies(FilterModel filters)
        {
            List<Movie> movies = facade.GetMovieRepository().GetAll();
            if (filters.SearchToken != null)
            {
                movies = movies.Where(c => c.Title.ToLower().Contains(filters.SearchToken.ToLower())).ToList();
            }
            if (filters.UseGenre)
            {
                movies = movies.Where(c => c.Genre.Id == filters.GenreId).ToList();
            }

            List<Genre> genres = facade.GetGenreRepository().GetAll();

            return View("Index", new IndexViewModel() { Movies = movies, Genres = genres });
            //return RedirectToAction("Index", new { movies = movies });
        }

        [HttpGet]
        public ActionResult Create() {

            EditMovieModel genre = new EditMovieModel();
            return View(genre);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            //[Bind(Include = "Title, Price, Year, Genre.Id, ImgUrl, TrailerUrl")]
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
        [ValidateAntiForgeryToken]
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