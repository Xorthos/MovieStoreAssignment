using MovieShopAdministrationAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.abstraction;
using Proxy.Facade.Implementation;

namespace MovieShopAdministrationAuth.Controllers
{
    public class MovieController : Controller
    {
        IFacade facade = new Facade();
        #region Index for Movies
        // GET: Movie
        public ActionResult Index()
        {
            //could this be done in a viewmodel?
            List<Movie> movies = (List<Movie>) facade.GetMovieGateway().GetAll();
            List<Genre> genres = (List<Genre>) facade.GetGenreGateway().GetAll();

            return View(new IndexViewModelHomeMade() { Movies = movies, Genres = genres });
        }
        #endregion

        #region Search for a Movie and filtering by Genre
        [HttpGet]
        public ActionResult FilterMovies(FilterModel filters)
        {
            List<Movie> movies = (List<Movie>) facade.GetMovieGateway().GetAll();
            if (filters.SearchToken != null)
            {
                movies = movies.Where(c => c.Title.ToLower().Contains(filters.SearchToken.ToLower())).ToList();
            }
            if (filters.UseGenre)
            {
                movies = movies.Where(c => c.Genre.Id == filters.GenreId).ToList();
            }

            List<Genre> genres = (List<Genre>) facade.GetGenreGateway().GetAll();

            return View("Index", new IndexViewModelHomeMade() { Movies = movies, Genres = genres });
            //return RedirectToAction("Index", new { movies = movies });
        }
        #endregion
        #region Create a movie
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
            movie.Genre = facade.GetGenreGateway().Get(movie.Genre.Id);
            facade.GetMovieGateway().Add(movie);
            return Redirect("Index");
        }
        #endregion

        #region Update a movie with a selected movieId
        [HttpGet]
        public ActionResult Edit(int movieId) {

            //could this be done in a view model?
            Movie theMovie = facade.GetMovieGateway().Get(movieId);
            List<Genre> genres = (List<Genre>) facade.GetGenreGateway().GetAll();
            EditMovieModel theViewModel = new EditMovieModel() { Movie = theMovie, Genres = genres };
            
            return View(theViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
                //METHOD NAME MIGHT CHANGE.
                movie.Genre = facade.GetGenreGateway().Get(movie.Genre.Id);
            //METHOD NAME MIGHT CHANGE.
            facade.GetMovieGateway().Update(movie);
            return Redirect("Index");

        }
        #endregion

        #region Delete a movie with a given movieId
        [HttpGet]
        public ActionResult Delete(int movieId)
        {
            Movie theMovie = facade.GetMovieGateway().Get(movieId);
            return View(theMovie);
        }
        [HttpPost]
        public ActionResult DeleteAccepted(int movieId)
        {
            facade.GetMovieGateway().Deactivate(movieId);
            return Redirect("Index");
        }
        #endregion
    }
}