using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopCustomer.Models
{
    public class CheckoutViewModel
    {
        public Customer Customer { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}