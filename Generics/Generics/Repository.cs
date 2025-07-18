using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal interface IEntity
    {
        int Id { get; }
    }
    internal class Repository<T> where T : IEntity
    {
        private List<T> values = new List<T>();

        public void Add(T entity)
        {
            values.Add(entity);
        }
    }

    internal interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
    }

    internal class ProductRepository : IRepository<Product>
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
