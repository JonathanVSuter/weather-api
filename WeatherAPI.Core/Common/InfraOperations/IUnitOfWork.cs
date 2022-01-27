using System;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IUnitOfWork : IDisposable
    {
        IDbSession _session { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
