using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopCustomer.Models
{
    public class IndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}