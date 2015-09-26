using Proxy.Context;
using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Repositories
{

    public abstract class MovieRepository<T>
    {
        /// <summary>
        /// Works by making a new context, it then pulls up the items, and removes 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            using (var ctx = new MovieShopContext())
            {

                GetAll(ctx).Add(item);
                ctx.SaveChanges();
            }
        }


        public void Remove(T item)
        {

        }
        public abstract List<T> GetAll(MovieShopContext ctx);
    }
}
