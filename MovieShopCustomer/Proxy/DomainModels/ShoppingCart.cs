using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DomainModels
{
    public class ShoppingCart
    {
        [Key]
        public string CustomerId { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
