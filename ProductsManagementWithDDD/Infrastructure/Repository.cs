using Microsoft.EntityFrameworkCore;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected DbContext DbContext { get; }
        protected DbSet<T> DbSet => DbContext.Set<T>();

        protected Repository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
        }

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public Task<T> GetByIdAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
