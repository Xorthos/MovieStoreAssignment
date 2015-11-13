using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proxy.DomainModels;

namespace MovieShopCustomerAuth.Models
{
    public class CartItem
    {
        public int MovieId { get; set; }

        public int Amount{ get; set; }          

        /// <summary>
        /// This is the item that will be stored in the cookies
        /// </summary>
        /// <param name="Id">The id of the movie</param>
        /// <param name="amount">The amount of that movie that is wanted</param>
        public CartItem(int Id, int amount)
        {
            MovieId = Id;
            Amount = amount;
        }
    }
}