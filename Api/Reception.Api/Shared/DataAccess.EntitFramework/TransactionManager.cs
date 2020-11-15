using DataAccess.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.EntityFramework
{
    /// <summary>
    /// Реализация менеджера транзакций.
    /// </summary>
    public class TransactionManager : ITransactionManager, IAsyncDisposable
    {
        private readonly DbContext _dbContext;

        public TransactionManager(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellation)
        {
            if (_dbContext.Database.CurrentTransaction == null)
                return _dbContext.Database.BeginTransactionAsync(cancellation);

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task CommitTransactionAsync(CancellationToken cancellation)
        {
            if (_dbContext.Database.CurrentTransaction != null)
                return _dbContext.Database.CurrentTransaction.CommitAsync(cancellation);

            throw new InvalidOperationException("Попытка закрыть несуществующую транзакцию.");
        }

        public void Dispose()
        {
            ((IDisposable)_dbContext).Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return ((IAsyncDisposable)_dbContext).DisposeAsync();
        }

        /// <inheritdoc/>
        public Task RollbackTransactionAsync(CancellationToken cancellation)
        {
            if (_dbContext.Database.CurrentTransaction != null)
                return _dbContext.Database.CurrentTransaction.RollbackAsync(cancellation);

            throw new InvalidOperationException("Попытка закрыть несуществующую транзакцию.");
        }
    }
}
