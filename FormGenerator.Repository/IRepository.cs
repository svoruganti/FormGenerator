using System;
using System.Linq;
using FormGenerator.Model;

namespace FormGenerator.Repository
{
    public interface IRepository<T> : IDisposable where T: Entity
    {
        IQueryable<T> GetQueryable();
        IQueryable<T> GetQueryableWithNoTracking();
        void Insert(T obj);
        void Update(T obj);
    }
}