using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopAdministrationAuth.Models
{
    public class FilterModel
    {
        public string SearchToken { get; set; }
        public int GenreId { get; set; }
        public bool UseGenre { get; set; }
    }
}