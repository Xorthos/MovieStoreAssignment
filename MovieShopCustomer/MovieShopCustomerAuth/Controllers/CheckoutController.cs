using MovieShopCustomerAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proxy.Facade.abstraction;
using Proxy.Facade.Implementation;

namespace MovieShopCustomerAuth.Controllers
{
    public class CheckoutController : Controller
    {
        private IFacade facade = new Facade();
        // GET: Checkout

        #region CheckoutView Index

        [HttpGet]
        [Authorize]
        public ActionResult Index(CheckoutViewModel checkout)
        {
            Customer customer = facade.GetCustomerGateway().Get(User.Identity.Name);

            //gets the cookie, and get the cart from that
            ShoppingCart cart = GetCart();
            return View("Index", new CheckoutViewModel() { Customer = customer, ShoppingCart = cart });
        }

        /// <summary>
        /// Gets the cart from the cookies
        /// </summary>
        /// <returns>the cart that was in the cookies</returns>
        private ShoppingCart GetCart()
        {
            //there is a potential error where someone would get to the page before the cart is created.
            HttpCookie cook = this.HttpContext.Request.Cookies.Get(CartController.CART_NAME);
            return JsonConvert.DeserializeObject<ShoppingCart>(cook.Value);

        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        #endregion

        #region Purchase 

        [HttpPost]
        [Authorize]
        public ActionResult Purchase()
        {
            Customer customer = facade.GetCustomerGateway().Get(User.Identity.Name);
            ShoppingCart cart = GetCart();

            for (int i = 0; i < cart.Orderline.Count; i++)
            {
                cart.Orderline[i].MovieId = cart.Orderline[i].Movie.Id;
                cart.Orderline[i].Price = cart.Orderline[i].Movie.Price;
            }

            Order order = new Order(cart.Orderline, customer);
            facade.GetOrderGateway().Add(order);

            cart.Orderline = new List<Orderline>();
            return View("Success");
            
        }
        #endregion
    }
}

