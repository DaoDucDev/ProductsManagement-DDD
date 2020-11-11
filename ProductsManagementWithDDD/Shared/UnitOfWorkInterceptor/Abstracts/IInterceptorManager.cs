using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UnitOfWorkInterceptor.Abstracts
{
    public interface IInterceptorManager
    {
        Task Execute(IEnumerable<EntityEntry> changeSet);
        Task BeforeCommit();
        Task AfterCommit();
    }
}
