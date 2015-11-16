using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace MovieShopCustomerAuth.Models
{
    public class ExchangeRateModel
    {
        public string code { get; set; }

        public string desc { get; set; }

        public double rate { get; set; }
    }
}