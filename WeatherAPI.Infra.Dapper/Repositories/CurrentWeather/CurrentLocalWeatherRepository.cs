using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class CurrentLocalWeatherRepository : ICurrentLocalWeatherRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        public CurrentLocalWeatherRepository(IOptions<ApiConfiguration> options) 
        {
            _options = options;
        }
        public int SaveCurrentLocalWeather(int coordinateId, CurrentLocalWeather currentLocalWeather)
        {            
            var sql = @"BEGIN
	                        DECLARE @idLocal INT;	
	                        SELECT @idLocal = l.Id FROM [Local] l WHERE l.Name = @name
	                        
                            IF LEN(ISNULL(CAST(@idLocal AS varchar(50)),'')) = 0
								BEGIN		                        
									INSERT INTO [dbo].[Local]
									([Name]
									,[Timezone]
									,[CoordinateId]
									,[CreatedAt]
									,[LastUpdate])
									OUTPUT Inserted.Id
								VALUES
									(@name
									,@timezone
									,@coordinateId
									,@createdAt
									,@lastUpdate)
								END
	                        ELSE
								BEGIN
									select @idLocal
								END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {                
                cmd.Parameters.AddWithValue("@name", currentLocalWeather.Name);
                cmd.Parameters.AddWithValue("@timezone", currentLocalWeather.Timezone);
                cmd.Parameters.AddWithValue("@coordinateId", coordinateId);               
                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
    }
}
