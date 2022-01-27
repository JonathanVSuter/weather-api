using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Configuration;

namespace WeatherAPI.Infra.Dapper.TransactionManagement
{
    public sealed class DbSession : IDbSession
    {
        public SqlConnection Connection { get; }
        public SqlTransaction Transaction { get; set; }

        public Guid Id {get;}

        public DbSession(IOptions<ApiConfiguration> options)
        {
            Id = Guid.NewGuid();
            Connection = new SqlConnection(options.Value.SqlServerConnection);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
