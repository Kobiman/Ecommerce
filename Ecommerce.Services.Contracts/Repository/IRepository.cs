using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces.Repository
{
    public interface IRepository<T>
    {
        public bool Add(T entity);
        //public bool Update(T entity);
        //public bool Update(T entity);
        public IList<T> GetAll();
        //public T GetById(string id);
        //public T GetById(int id);
    }
}
