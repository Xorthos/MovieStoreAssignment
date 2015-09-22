using Proxy.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Context
{
    class GenreContext
    {
        public DbSet<Genre> Genres { get; set; }
    }
}
