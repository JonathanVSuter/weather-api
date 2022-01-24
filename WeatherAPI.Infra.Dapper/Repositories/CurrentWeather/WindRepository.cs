using Microsoft.Extensions.Options;
using System;
using System.Data.SqlClient;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class WindRepository : IWindRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        public WindRepository(IOptions<ApiConfiguration> options) 
        {
            _options = options;
        }
        public int SaveWind(Wind wind)
        {
            var sql = @"BEGIN	
	                        DECLARE @idWind INT;	
	                        select @idWind = w.Id from Wind w where w.Speed = @speed and w.Degree = @degree and w.Gust = @gust
	                        
                            IF LEN(ISNULL(CAST(@idWind AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO [dbo].[Wind]([Speed],[Degree],[Gust],[CreatedAt],[LastUpdate]) OUTPUT Inserted.ID VALUES (@speed, @degree, @gust, @createdAt, @lastUpdate)
	                        END
	                        ELSE
	                        BEGIN
		                        select @idWind
	                        END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@speed", wind.Speed);
                cmd.Parameters.AddWithValue("@degree", wind.Deg);
                cmd.Parameters.AddWithValue("@gust", wind.Gust);
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
