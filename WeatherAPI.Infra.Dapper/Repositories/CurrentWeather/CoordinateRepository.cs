using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Dapper.Connections;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class CoordinateRepository : ICoordinateRepository
    {
        private readonly IOptions<ApiConfiguration> _options;

        public CoordinateRepository(IOptions<ApiConfiguration> options) 
        {
            _options = options;
        }
        public int SaveCoordinate(Coordinate coordinate)
        {
            var sql = @"BEGIN	
	                        DECLARE @idCoordinate INT;	
	                        select @idCoordinate = c.Id from Coordinate c where c.Latitude = @latitude and c.Longitude = @longitude 
	                        
                            IF LEN(ISNULL(CAST(@idCoordinate AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO [dbo].[Coordinate] ([Longitude],[Latitude],[CreatedAt],[LastUpdate]) OUTPUT Inserted.ID VALUES (@longitude, @latitude, @createdAt,@lastUpdate)
	                        END
	                        ELSE
	                        BEGIN
		                        select @idCoordinate
	                        END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@longitude", coordinate.Lon);
                cmd.Parameters.AddWithValue("@latitude", coordinate.Lat);
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
