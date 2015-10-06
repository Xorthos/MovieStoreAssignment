using MovieShopCustomer.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopCustomer.Controllers
{
    public class HomeController : Controller
    {
        Facade facade = new Facade();
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
        }

        public ActionResult Test()
        {
            return View(facade.GetOrderRepository().GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}