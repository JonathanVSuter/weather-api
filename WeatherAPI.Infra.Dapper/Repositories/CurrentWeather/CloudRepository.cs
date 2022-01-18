using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Dapper.Connections;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class CloudRepository : ICloudRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        public CloudRepository(IOptions<ApiConfiguration> options) 
        {
            _options = options;
        }
        public int SaveCloudRepository(Clouds clouds)
        {
            var sql = @"USE [weatherapp.dev]
                        INSERT INTO[dbo].[Cloud]
                                   ([Cloudiness]                                   
                                   ,[CreatedAt]
                                   ,[LastUpdate])
                             VALUES
                                   (@cloudiness
                                   ,GETDATE()
                                   ,GETDATE())";

            var parameters = new SqlServerDynamicParameters();
            parameters.Add("@cloudiness", SqlDbType.Real, ParameterDirection.Input, clouds.All);
            using var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            sqlConnection.Open();
            var result = sqlConnection.Execute(sql, parameters);
            sqlConnection.Close();

            return result;
        }
    }
}
