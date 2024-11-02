using Gallery.Domain.Interfaces;
using Gallery.Repository.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected GalleryDbContext _dbContext;
        private DbSet<T> _dbSet;

        public RepositoryBase(IGalleryDbContext dbContext)
        {
            _dbContext = (dbContext as GalleryDbContext) ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public virtual T Get(params object[] key)
        {
            return _dbSet.Find(key);
        }

        public IEnumerable<T> Set(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Save(T item)
        {
            if (_dbContext.Entry(item) == null || _dbContext.Entry(item).State == EntityState.Detached)
            {
                _dbSet.Add(item);
            }
        }

        public virtual void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public virtual void Delete(params object[] key)
        {
            Delete(Get(key));
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
