using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using MovieShopCustomerAuth.Models;
using Newtonsoft.Json;
using Proxy.DomainModels;
using Proxy.Facade;
using Proxy.Facade.Implementation;
using ShoppingCartView = MovieShopCustomerAuth.Models.ShoppingCartView;

namespace MovieShopCustomerAuth.Controllers
{
    public class CartController : Controller
    {
    #region Constansts
        public static readonly string CART_NAME = "ShoppingCartDone";
        public static readonly int PERSISTANCE_TIME = 1;
    #endregion

    #region Make Cart

        /// <summary>
        /// Creates the shopping cart that will be persisted in the cookies.
        /// </summary>
        private bool MakeShoppingCart()
        {

            HttpCookie myCookie = this.HttpContext.Request.Cookies.Get(CART_NAME);

            if (myCookie == null)
            {
                myCookie = new HttpCookie(CART_NAME);
                var cart = new ShoppingCart();
                myCookie.Value = JsonConvert.SerializeObject(cart);
                myCookie.Expires = DateTime.Now.AddDays(PERSISTANCE_TIME);

                this.HttpContext.Response.Cookies.Add(myCookie);
                return true;
            }
            return false;

        }
        #endregion

    #region Get Cart

        /// <summary>
        /// Will return a list of the movies in the shopping cart.
        /// </summary>
        /// <returns>A list of movie, that is found in cookies</returns>
        [HttpGet]
        public ActionResult ShoppingCart()
        {
            MakeShoppingCart();
            HttpCookie myCookie = Request.Cookies.Get(CART_NAME);

            var cart = JsonConvert.DeserializeObject<ShoppingCart>(myCookie.Value);

            return View(cart);
        }

        #endregion

    #region Add item to Cart
        /// <summary>
        /// Will add an item to the shoppingcart
        /// </summary>
        /// <param name="item">The item to be added to the shoppingcart</param>
        /// <returns>Will return to the index of the movie thing</returns>
        [HttpPost]
        public ActionResult AddToShoppingCart(int movieId, int amount)
        {
            MakeShoppingCart();
            HttpCookie myCookie = Request.Cookies.Get(CART_NAME);
            
            ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(myCookie.Value);

            if (lookInCart(cart,movieId))
            {
                var orderline = cart.Orderline.First(c => c.Movie.Id == movieId);
                orderline.Amount += amount;
            }
            else
            {
                var mov = new Facade().GetMovieGateway().Get(movieId);
                cart.Orderline.Add(new Orderline() { Amount = amount, Movie = mov });
            }


            myCookie.Value = JsonConvert.SerializeObject(cart);

            myCookie.Expires = DateTime.Now.AddDays(PERSISTANCE_TIME); // this will make the cart persist longer.

            this.HttpContext.Response.Cookies.Set(myCookie);
            return RedirectToAction("Index","Home");
            //this should allow you to return nothing, I imagine that this could be useful
            //for JavaScript 
            // return null  
        }

        /// <summary>
        /// Looks in the cart to see if it contains a specific object
        /// </summary>
        /// <param name="cart">the cart to look in</param>
        /// <param name="movieId">the id of the movie.</param>
        /// <returns>true if it contains the movie</returns>
        private bool lookInCart(ShoppingCart cart, int movieId)
        {
            foreach (var item in cart.Orderline)
            {
                if (item.Movie.Id == movieId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deletes a specified item from the cart
        /// </summary>
        /// <param name="movieId">the id of the movie</param>
        /// <returns>redirects to index</returns>
        [HttpPost]
        public ActionResult DeleteItemFromCart(int movieId)
        {
            if (MakeShoppingCart())
            {
                return RedirectToAction("Index", "Home");
            }

            //gets the cart from the cookies
            HttpCookie myCookie = Request.Cookies.Get(CART_NAME);
            ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(myCookie.Value);

            //removes the item from the cookie, or returns to the index if the item was not there.
            if (!lookInCart(cart, movieId))
            {
                cart.Orderline.Remove(cart.Orderline.First(c => c.MovieId == movieId));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //saves the new values in the cookies
            myCookie.Value = JsonConvert.SerializeObject(cart);
            myCookie.Expires = DateTime.Now.AddDays(PERSISTANCE_TIME); // this will make the cart persist longer.
            this.HttpContext.Response.Cookies.Set(myCookie);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        /// <summary>
        /// Cleans the cart
        /// </summary>
        /// <returns>redicrects to the index</returns>
        [HttpPost]
        public ActionResult CleanCart()
        {
            this.HttpContext.Response.Cookies.Remove(CART_NAME);
            return RedirectToAction("Index", "Home");
        }
    }


}