using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IUnitOfWork: IDisposable
    {
        //Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
