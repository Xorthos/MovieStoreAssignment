using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{
    public class ShoppingCartRepository
    {
        public void Add(ShoppingCart cart)
        {
            using(MovieShopContext con = new MovieShopContext())
            {
                con.ShoppingCarts.Add(cart);
                con.SaveChanges();
            }
        }

        public List<ShoppingCart> GetAll()
        {
            using (MovieShopContext con = new MovieShopContext())
            {
                return con.ShoppingCarts.Include("Movies").ToList();
            }

        }

        public ShoppingCart Get(string ShopId)
        {
            using (MovieShopContext con = new MovieShopContext())
            {
                return con.ShoppingCarts.Where(c => c.CustomerId.Equals(ShopId)).FirstOrDefault();
            }
        }

        public void Delete(string ShopId)
        {
            using (var ctx = new MovieShopContext())
            {
                var shoppingCart = ctx.ShoppingCarts.Where(c => c.CustomerId.Equals(ShopId)).FirstOrDefault();
                ctx.ShoppingCarts.Remove(shoppingCart);
                ctx.SaveChanges();
            }
        }

        public void Edit(ShoppingCart cart)
        {
            using (var ctx = new MovieShopContext())
            {
                var shoppingCart = ctx.ShoppingCarts.Where(c => c.CustomerId.Equals(cart.CustomerId)).FirstOrDefault();
                shoppingCart.Movies = cart.Movies;
                ctx.SaveChanges();
            }
        }
    }
}
