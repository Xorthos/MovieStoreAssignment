using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proxy.DomainModels;
using Proxy.Facade;

namespace MovieShopCustomerAuth.Controllers
{
    public class CartController : Controller
    {
    #region Constansts
        private const string CART_NAME = "ShoppingCart";
    #endregion
    #region Make Cart
        /// <summary>
        /// Creates the shopping cart that will be persisted in the cookies.
        /// </summary>
        public void MakeShoppingCart()
        {
            if (Request[CART_NAME] == null)
            {
                HttpCookie myCookie = new HttpCookie(CART_NAME);
                myCookie.Expires = DateTime.Now.AddDays(1); // this means that the cookie will be persisted for 1 day
                Response.Cookies.Add(myCookie);
            }
        }
        #endregion

    #region Get Cart

        /// <summary>
        /// Will return a list of the movies in the shopping cart.
        /// </summary>
        /// <returns>A list of movie, that is found in cookies</returns>
        public List<Movie> GetCart()
        {
            List<Movie> result = new List<Movie>();
            
            foreach (var item in Request.Cookies[CART_NAME].Values)
            {

            }
            return result;
        }

        #endregion
    #region Add item to Cart
        /// <summary>
        /// Will add an item to the shoppingcart
        /// </summary>
        /// <param name="item">The item to be added to the shoppingcart</param>
        /// <returns>Will return to the index of the movie thing</returns>
        public ActionResult AddToShoppingCar(Movie item)
        {
            var myCookie = Request.Cookies[CART_NAME];

            myCookie.Values.Add("", item.Id.ToString());
            myCookie.Expires = DateTime.Now.AddDays(1); // this will make the cart persist one day.

            return RedirectToAction("Index","Home");
            //this should allow you to return nothing, I imagine that this could be useful
            //for JavaScript 
            // return null  
        }
#endregion
    }
}