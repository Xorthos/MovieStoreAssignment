using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Orderline = new List<Orderline>();
        }
        [Key]
        public string CustomerId { get; set; }
        public List<Orderline> Orderline { get; set; }
    }
}