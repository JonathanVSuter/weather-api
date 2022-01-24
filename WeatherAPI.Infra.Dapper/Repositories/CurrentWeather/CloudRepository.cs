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
        public int SaveCloud(Cloud clouds)
        {
            var sql = @"BEGIN	
	                        DECLARE @idCloud INT;	
	                        SELECT @idCloud = c.Id from Cloud c where c.Cloudiness = @cloudiness
	                        
                            IF LEN(ISNULL(CAST(@idCloud AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO Cloud (Cloudiness, CreatedAt, LastUpdate) OUTPUT Inserted.ID values (@cloudiness, GETDATE(), GETDATE())
	                        END
	                        ELSE
	                        BEGIN
		                        select @idCloud
	                        END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@cloudiness", clouds.All);
                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();
                return result;
            }

        }
    }
}