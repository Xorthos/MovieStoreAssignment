using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopCustomer.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCustomer(Customer cust)
        {
            if (ModelState.IsValid)
            {
                new Facade().GetCustomerRepository().Add(cust);
                return Redirect("Index");
            }
            return View(cust);
        }

        public ActionResult UserLogOut()
        {
            Session["UserId"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}