using System;
using System.Threading.Tasks;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IUnitOfWork : IDisposable
    {
        IDbSession _session { get; }
        void BeginTransaction();
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}
