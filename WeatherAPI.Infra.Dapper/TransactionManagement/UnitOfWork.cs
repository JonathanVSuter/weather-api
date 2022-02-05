using System.Threading.Tasks;
using WeatherAPI.Core.Common.InfraOperations;

namespace WeatherAPI.Infra.Dapper.TransactionManagement
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbSession _session { get; }

        public UnitOfWork(IDbSession dbSession)
        {
            _session = dbSession;
        }
        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }
        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }
        public async Task CommitAsync()
        {
            await _session.Transaction.CommitAsync().ConfigureAwait(true);
        }
        public IDbSession DbSession()
        {
            return _session;
        }
        public void Dispose()
        {
            _session.Transaction?.Dispose();
        }
        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }
        public async Task RollbackAsync()
        {
            await _session.Transaction.RollbackAsync().ConfigureAwait(true);
            Dispose();
        }
    }
}
