using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopAdministrationAuth.Models
{
    public class IndexViewModelHomeMade
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}