using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Seeding
{
    public class Initializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DBInitializer());
        }
    }
}
