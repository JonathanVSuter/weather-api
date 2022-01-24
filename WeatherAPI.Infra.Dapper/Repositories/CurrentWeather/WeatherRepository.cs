using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        public WeatherRepository(IOptions<ApiConfiguration> options) 
        {
            _options = options;
        }

        public int SaveWeather(Weather weather)
        {
            var sql = @"BEGIN	
	                        DECLARE @idWeather INT;	
	                        SELECT @idWeather = w.Id FROM Weather w WHERE w.Id = @id
	                        
                            IF LEN(ISNULL(CAST(@idWeather AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO [dbo].[Weather]([Id],[Main],[Description],[Icon],[CreatedAt],[LastUpdate]) OUTPUT Inserted.ID VALUES (@id,@main,@description,@icon,@createdAt,@lastUpdate)
	                        END
	                        ELSE
	                        BEGIN
		                        select @idWeather
	                        END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@id", weather.Id);
                cmd.Parameters.AddWithValue("@main", weather.Main);
                cmd.Parameters.AddWithValue("@description", weather.Description);
                cmd.Parameters.AddWithValue("@icon", weather.Icon);
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
