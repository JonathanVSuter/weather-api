using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class WeatherRelationshipsFinisherRepository : IWeatherRelationshipsFinisherRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        public WeatherRelationshipsFinisherRepository(IOptions<ApiConfiguration> options) 
        {
            _options = options;
        }
        public void AttachLocalCloud(int idLocal, int idCloud)
        {
            var sql = @"INSERT INTO [dbo].[Local_Cloud]
                                   ([fk_Local_Id]
                                   ,[fk_Cloud_Id]
                                   ,[CreatedAt]
                                   ,[LastUpdate])
                             VALUES
                                   (@idLocal
                                   ,@idCloud
                                   ,@createdAt
                                   ,@lastUpdate)";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@idLocal", idLocal);
                cmd.Parameters.AddWithValue("@idCloud", idCloud);
                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);                

                sqlConnection.Open();
                cmd.ExecuteScalar();
                sqlConnection.Close();
            };
        }

        public void AttachLocalWeather(int idLocal, IList<int> idWeathers)
        {
            var sql = @"INSERT INTO [dbo].[Local_Weather]
                               ([fk_Local_Id]
                               ,[fk_Weather_Id]
                               ,[createdAt]
                               ,[updatedAt])
                         VALUES
                               (@idLocal
                               ,@idWeather
                               ,@createdAt
                               ,@lastUpdate)";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);

            foreach (var idWeather in idWeathers) 
            {
                
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@idLocal", idLocal);
                    cmd.Parameters.AddWithValue("@idWeather", idWeather);
                    cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);

                    sqlConnection.Open();
                    cmd.ExecuteScalar();
                    sqlConnection.Close();
                };
            }            
        }

        public void AttachLocalWind(int idLocal, int idWind)
        {
            var sql = @"INSERT INTO [dbo].[Local_Wind]
                                   ([fk_Local_Id]
                                   ,[fk_Wind_Id]
                                   ,[CreatedAt]
                                   ,[LastUpdate])
                             VALUES
                                   (@idLocal
                                   ,@idWind
                                   ,@createdAt
                                   ,@lastUpdate)";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@idLocal", idLocal);
                cmd.Parameters.AddWithValue("@idWind", idWind);
                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);

                sqlConnection.Open();
                cmd.ExecuteScalar();
                sqlConnection.Close();
            };            
        }
    }
}
