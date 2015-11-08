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
    public class CheckoutController : Controller
    {
        IFacade facade = new Facade();
        // GET: Checkout
        #region CheckoutView Index
        [HttpGet]
        public ActionResult Index(CheckoutViewModel checkout)
        {
            try
            {   
                int userId = (int)Session["UserId"];
                Customer customer = facade.GetCustomerGateway().Get(userId);
                ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
                return View("Index", new CheckoutViewModel() { Customer = customer, ShoppingCart = cart });
            }
            catch
            {
                return View("LogInAndTryAgain");
            }
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        #endregion

        #region Delete a movie from ShoppingCart
        [HttpGet]
        public ActionResult Delete(int movieId)
        {
            try
            {
                ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
                for(int i = 0; i < cart.Orderline.Count; i++)
                {
                    if (cart.Orderline[i].Movie.Id == movieId) {
                        cart.Orderline.RemoveAt(i);
                    }
                }
                return Redirect("Index");
            }
            catch
            {
                return Redirect("Home/Index");
            }
        }
        #endregion

        #region Purchase 
        [HttpPost]
        public ActionResult Purchase() {
            try {
                int userId = (int)Session["UserId"];
                Customer customer = facade.GetCustomerGateway().Get(userId);
                ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
                
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
            catch
            {
                return View("Error");
            }
        }
        #endregion

      
    }
}
    
