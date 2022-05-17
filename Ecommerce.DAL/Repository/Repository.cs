using Ecommerce.Services.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repository
{
    public class Repository<T> : IRepository<T>
    {
        protected IList<T> Collection { get; }

        public Repository(IList<T> collection)
        {
            Collection = collection;
        }

        public bool Add(T entity)
        {
            Collection.Add(entity);
            return true;
        }

        public IList<T> GetAll()
        {
            return Collection;
        }

        //public T GetById(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
