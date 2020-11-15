using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Abstraction
{
    /// <summary>
    /// Менеджер транзакций.
    /// </summary>
    public interface ITransactionManager
    {
        /// <summary>
        /// Начинает транзакцию с заданным уровнем изоляции.
        /// </summary>
        /// <param name="isolationLevel">Уровень изоляции.</param>
        Task BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellation);

        /// <summary>
        /// Фиксирует изменения.
        /// </summary>
        Task CommitTransactionAsync(CancellationToken cancellation);

        /// <summary>
        /// Отменяет изменения.
        /// </summary>
        Task RollbackTransactionAsync(CancellationToken cancellation);
    }
}
