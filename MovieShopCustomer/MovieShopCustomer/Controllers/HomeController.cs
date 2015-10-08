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
            if(Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new ShoppingCart();
            }
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

        public ActionResult ShoppingCart()
        {
                return View(Session["ShoppingCart"] as ShoppingCart);
        }

        public ActionResult AddMovieToCart(int movieId, int amount)
        {
            Orderline line = new Orderline() { Movie = facade.GetMovieRepository().GetMovie(movieId), Amount = amount };
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            cart.Orderline.Add(line);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult UserLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogIn(string UserEmail, string UserPassword)
        {
            Customer cust = facade.GetCustomerRepository().GetCustomer(UserEmail);
            if(cust != null && cust.Password.Equals(UserPassword))
            {
                Session["UserName"] = cust.FirstName + " " + cust.LastName;
                Session["UserId"] = cust.Id;
            }
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("OrderFailed");
        }
    }
}