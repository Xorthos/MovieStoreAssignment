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
        #region Home Index
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
        #endregion

        #region Search between movies and filter option by genres
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
        #endregion

        #region ShoppingCart
        public ActionResult ShoppingCart()
        {
            return View(Session["ShoppingCart"] as ShoppingCart);
        }
        #endregion

        #region Adding a movie to the shoppingCart
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
        #endregion

        #region Increase the amount if it exist
        private bool IncrimentIfInCart(int movieId, int amount)
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
        #endregion

        #region UserLogin
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
        #endregion

        #region UserProfile
        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }
        #endregion

        #region Change a Password
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
        #endregion

        #region Change a Customer Information
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
        #endregion

        #region ViewOrders
        [HttpGet]
        public ActionResult ViewOrders()
        {
            return View(facade.GetOrderRepository().GetOrders((int)Session["UserId"]));
        }
        #endregion

    }
}