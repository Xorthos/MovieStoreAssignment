using MovieShopCustomerAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.abstraction;
using Proxy.Facade.Implementation;

namespace MovieShopCustomerAuth.Controllers
{
    
    public class HomeController : Controller
    {
        IFacade facade = new Facade();
        #region Home Index
        public ActionResult Index()
        {
            if (Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new ShoppingCart();
            }

            //This should be done in the viewmodel
            List<Movie> movies = (List<Movie>) facade.GetMovieGateway().GetAll();
            List<Genre> genres = (List<Genre>) facade.GetGenreGateway().GetAll();
            // to here

            return View(new IndexViewModelHomeMade() { Movies = movies, Genres = genres });
        }
        #endregion

        #region Search between movies and filter option by genres
        [HttpGet]
        public ActionResult FilterMovies(FilterModel filters)
        {
            // could this be done in a view model? If so we need to do it, and test it!
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
            //could this be done in a view model? if so we need to do it, and test it!
            Orderline line = new Orderline() { Movie = facade.GetMovieGateway().Get(movieId), Amount = amount };
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
            Customer cust = facade.GetCustomerGateway().Get(UserEmail);
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

        /// <summary>
        /// The changes to the gateway, and athorization has made this both not work, and not necessary
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePass(ChangePassModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Customer cust = facade.GetCustomerGateway().Get((int)Session["UserId"]);
                if (cust.Password.Equals(viewModel.OldPassword))
                {
                    cust.Password = viewModel.Password;
                    //facade.GetCustomerGateway().ChangePassword(cust);
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
            return View(facade.GetCustomerGateway().Get((int)Session["UserId"]));
        }

        [HttpPost]
        public ActionResult ChangeInfo([Bind(Include ="FirstName, MiddleName, LastName, StreetName, StreetNumber, Email")] Customer cust)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                Session["UserName"] = cust.FirstName + " " + cust.LastName;
                cust.Id = (int)Session["UserId"];
                facade.GetCustomerGateway().Update(cust);

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
            return View(facade.GetOrderGateway().GetOrders((int)Session["UserId"]));
        }
        #endregion

    }
}