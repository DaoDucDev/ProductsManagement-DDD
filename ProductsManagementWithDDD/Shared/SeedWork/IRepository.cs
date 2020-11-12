using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.SeedWork
{
    public interface IRepository<T> where T: IAggregateRoot
    {
        void Add(T entity);
        Task<T> GetByIdAsync(Guid entityId);
        //Task<T> GetSingleAsync(ISpecification<T> spec, string[] sorts = null);
    }
}
