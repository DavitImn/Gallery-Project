using System;
using System.Collections.Generic;

namespace Gallery.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(params object[] key);
        IEnumerable<T> Set(Func<T,bool> predicate);
        void Save(T item);
        void Delete(T item);
        void Delete(params object[] key);
        int SaveChanges();
    }
}
