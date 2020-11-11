using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UnitOfWorkInterceptor.Abstracts
{
    public interface IOnAdd<T> where T : class
    {
        Task OnAdd(T entity);
    }
}
