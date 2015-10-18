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
    public class CheckoutController : Controller
    {
        Facade facade = new Facade();
        // GET: Checkout
        #region CheckoutView Index
        [HttpGet]
        public ActionResult Index(CheckoutViewModel checkout)
        {
            try
            {   
                int userId = (int)Session["UserId"];
                Customer customer = facade.GetCustomerRepository().GetCustomer(userId);
                ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
                return View("Index", new CheckoutViewModel() { Customer = customer, ShoppingCart = cart });
            }
            catch
            {
                return Redirect("Home/Index");
            }
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("OrderFailed");
        }
        #endregion
        #region Delete an orderline
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
        [HttpGet]
        public ActionResult Purchase() {
            try {
                int userId = (int)Session["UserId"];
                Customer customer = facade.GetCustomerRepository().GetCustomer(userId);
                ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;

                for (int i = 0; i < cart.Orderline.Count; i++)
                {
                    cart.Orderline[i].MovieId = cart.Orderline[i].Movie.Id;
                    cart.Orderline[i].Price = cart.Orderline[i].Movie.Price;
                }
                Order order = new Order(cart.Orderline, customer);
                facade.GetOrderRepository().Add(order);

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
    
