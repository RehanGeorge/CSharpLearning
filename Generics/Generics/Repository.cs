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
    internal class Repository<T> : IRepository<T>
    {
        private List<T> values = new List<T>();

        public void Add(T entity)
        {
            values.Add(entity);
        }

        public void Remove(T entity)
        {
            values.Remove(entity);
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

    internal class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class  User : IEntity
    {
        public string Name { get; set; }

        public int Id => throw new NotImplementedException();
    }

    internal class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
