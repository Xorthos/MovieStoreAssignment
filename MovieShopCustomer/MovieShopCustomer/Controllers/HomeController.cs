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
            if (Session["ShoppingCart"] == null)
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
            if (IncrimentIfInCart(movieId, amount))
            {
                return Redirect("Index");
            }
            Orderline line = new Orderline() { Movie = facade.GetMovieRepository().GetMovie(movieId), Amount = amount };
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            cart.Orderline.Add(line);
            return Redirect("Index");
        }

        public bool IncrimentIfInCart(int movieId, int amount)
        {
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            foreach (var item in cart.Orderline)
            {
                if(item.Movie.Id == movieId)
                {
                    item.Amount += amount;
                    return true;
                }
            }
            return false;
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
            if (cust != null && cust.Password.Equals(UserPassword))
            {
                Session["UserName"] = cust.FirstName + " " + cust.LastName;
                Session["UserId"] = cust.Id;
            }
            return Redirect("Index");
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

        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(ChangePassModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Customer cust = facade.GetCustomerRepository().GetCustomer((int)Session["UserId"]);
                if (cust.Password.Equals(viewModel.OldPassword))
                {
                    cust.Password = viewModel.Password;
                    facade.GetCustomerRepository().ChangePassword(cust);
                    ViewBag.PreviousFail = null;

                }
                else
                {
                    ViewBag.PreviousFail = true;
                    return View(viewModel);
                }
                return RedirectToAction("UserProfile");
            }
            else
            {
                return View(viewModel);
            }
        }
        [HttpGet]
        public ActionResult ChangeInfo()
        {
            return View(facade.GetCustomerRepository().GetCustomer((int)Session["UserId"]));
        }

        [HttpPost]
        public ActionResult ChangeInfo([Bind(Include ="FirstName, MiddleName, LastName, StreetName, StreetNumber, Email")] Customer cust)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                Session["UserName"] = cust.FirstName + " " + cust.LastName;
                cust.Id = (int)Session["UserId"];
                facade.GetCustomerRepository().ChangeCustomer(cust);

                return RedirectToAction("UserProfile");
            }
            else
            {
                return View(cust);
            }
        }

        [HttpGet]
        public ActionResult ViewOrders()
        {
            return View(facade.GetOrderRepository().GetOrders((int)Session["UserId"]));
        }
    }
}