﻿using MovieShopCustomerAuth.Models;
using Proxy.DomainModels;
using Proxy.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy.Facade.Implementation;

namespace MovieShopCustomerAuth.Controllers
{
    public class CustomerController : Controller
    {

        // I THINK THAT GOOD ARGUMENTS CAN BE MADE TO KILL THIS CONTROLLER
        #region Customer Index
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Create a new Customer
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
        public ActionResult NewCustomer(RegisterModel registerModel)
        {
            ModelState.Remove("Customer.Password");
            if (ModelState.IsValid)
            {
                registerModel.Customer.Password = registerModel.Password;
                new Facade().GetCustomerGateway().Add(registerModel.Customer);
                return RedirectToAction("Index", "Home");
            }
            return View(registerModel);
        }
        #endregion

        #region UserLogOut
        public ActionResult UserLogOut()
        {
            Session["UserId"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}