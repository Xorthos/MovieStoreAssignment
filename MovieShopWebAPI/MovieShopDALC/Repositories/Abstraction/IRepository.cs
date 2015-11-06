using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDALC.Repositories.Abstraction
{
    public interface IRepository<T>
    {
        T Add(T item);

        IEnumerable<T> GetAll();

        T Get(int id);

        T Update(T item);

        bool ChangeActive(T item);
    }
}
