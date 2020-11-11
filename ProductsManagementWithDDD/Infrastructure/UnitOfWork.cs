using Domain.SeedWork;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.UnitOfWorkInterceptor.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IInterceptorManager _interceptors;

        public UnitOfWork(ProductContext dbContext, IInterceptorManager interceptorManager, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _interceptors = interceptorManager;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await _interceptors.BeforeCommit();
                var changeSet = _dbContext.ChangeTracker.Entries()
                    .Where(t => t.State != EntityState.Unchanged && t.State != EntityState.Detached).ToList();
                await _interceptors.Execute(changeSet);
                await _dbContext.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                await _interceptors.AfterCommit();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unit of work commit failed");
                transaction.Rollback();
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_dbContext == null)
            {
                return;
            }

            _dbContext.Dispose();
            _dbContext = null;
        }

    }
}
