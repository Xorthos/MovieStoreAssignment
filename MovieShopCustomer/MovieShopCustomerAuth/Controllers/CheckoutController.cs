using MovieShopCustomerAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
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
            GetCurrencies();
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

        private void GetCurrencies()
        {
            if (Session["ExchangeRateList"] == null)
            {
                XmlReader reader = XmlReader.Create("http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da");
                List<ExchangeRateModel> exchangeRates = new List<ExchangeRateModel>();

                ExchangeRateModel DKK = new ExchangeRateModel() { code = "DKK", desc = "Danske kroner", rate = 1 };
                Session["CurrentRate"] = DKK;
                exchangeRates.Add(DKK);

                while (reader.Read())
                {
                    if (reader.HasAttributes)
                    {
                        ExchangeRateModel exchangeRateModel = new ExchangeRateModel()
                        {
                            code = reader.GetAttribute("code"),
                            desc = reader.GetAttribute("desc")
                        };
                        double tempRate;
                        double.TryParse(reader.GetAttribute("rate"), out tempRate);
                        exchangeRateModel.rate = tempRate;

                        exchangeRates.Add(exchangeRateModel);
                    }
                }
                Session["ExchangeRateList"] = exchangeRates;

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

        public ActionResult UpdateCurrency(string code)
        {
            
            foreach (ExchangeRateModel rate in (List<ExchangeRateModel>)Session["ExchangeRateList"])
            {
                if (rate.code.Equals(code))
                {
                    Session["CurrentRate"] = rate;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
    
