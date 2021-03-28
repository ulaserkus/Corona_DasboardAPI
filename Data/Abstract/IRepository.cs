using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Data.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

     

    }
}
