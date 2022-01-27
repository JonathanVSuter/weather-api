using System;
using System.Data;
using System.Data.SqlClient;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IDbSession : IDisposable
    {
        Guid Id { get; }
        SqlConnection Connection { get; }
        SqlTransaction Transaction { get; set; }
    }
}
