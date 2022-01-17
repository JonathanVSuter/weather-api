using System;
using System.Data;
using System.Data.Common;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        DbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginScope(DbConnection dbConnection);
        void Commit();
        void Rollback();
    }
}
