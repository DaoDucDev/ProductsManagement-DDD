using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UnitOfWorkInterceptor.Abstracts
{
    public interface IOnUpdate<T> where T : class
    {
        Task OnUpdate(T entity);
    }
}
