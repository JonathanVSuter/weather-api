using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Common.Pagination;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Dapper.Extensions;
using WeatherAPI.Infra.Dapper.Pagination;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class CurrentWeatherRepository : ICurrentWeatherRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        private readonly IUnitOfWork _unitOfWork;
        public CurrentWeatherRepository(IOptions<ApiConfiguration> options, IUnitOfWork unitOfWork)
        {
            _options = options;
            _unitOfWork = unitOfWork;
        }
        public int SaveCloud(Cloud clouds, DateTime createdDate)
        {
            //Change the name of column 'All' to other name
            var sql = @"BEGIN	
	                        DECLARE @idCloud INT;	
	                        SELECT @idCloud = c.Id from Cloud c where c.AllClouds = @allClouds
	                        
                            IF LEN(ISNULL(CAST(@idCloud AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO Cloud (AllClouds, CreatedDate, UpdatedDate) OUTPUT Inserted.Id values (@allClouds, @createdDate, @updatedDate)
	                        END
	                        ELSE
	                        BEGIN
		                        select @idCloud
	                        END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@allClouds", clouds.All);
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updatedDate", createdDate);
                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();
                return result;
            }
        }
        public int SaveWeather(Weather weather, DateTime createdDate)
        {
            var sql = @"BEGIN	
	                        DECLARE @idWeather INT;	
	                        SELECT @idWeather = w.Id FROM Weather w WHERE w.Id = @id
	                        
                            IF LEN(ISNULL(CAST(@idWeather AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO Weather(Id,Main,Description,Icon,CreatedDate,UpdatedDate) OUTPUT Inserted.ID VALUES (@id,@main,@description,@icon,@createdDate,@updatedDate)
	                        END
	                        ELSE
	                        BEGIN
		                        SELECT @idWeather
	                        END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@id", weather.Id);
                cmd.Parameters.AddWithValue("@main", weather.Main);
                cmd.Parameters.AddWithValue("@description", weather.Description);
                cmd.Parameters.AddWithValue("@icon", weather.Icon);
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updatedDate", createdDate);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public int SaveCurrentLocalWeather(int idLocal, int idCloud, int idWind, int idCoordinate, int idSysAttributes, int idAtmosphereConditions, DateTime createdDate)
        {
            var sql = @"INSERT INTO Current_Local_Weather
                               (Wind_Id
                               ,Local_Id
                               ,Coordinate_Id
                               ,Atmosphere_conditions_Id
                               ,Clouds_Id
                               ,SysAttributes_Id
                               ,CreatedDate
                               ,UpdateDate)
                               OUTPUT Inserted.Id
                         VALUES
                               (@windId
                               ,@localId
                               ,@coordinateId
                               ,@atmosphereConditionsId
                               ,@cloudId
                               ,@sysattributesId
                               ,@createdDate
                               ,@updatedDate)";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@windId", idWind);
                cmd.Parameters.AddWithValue("@localId", idLocal);
                cmd.Parameters.AddWithValue("@coordinateId", idCoordinate);
                cmd.Parameters.AddWithValue("@atmosphereConditionsId", idAtmosphereConditions);
                cmd.Parameters.AddWithValue("@cloudId", idCloud);
                cmd.Parameters.AddWithValue("@sysattributesId", idSysAttributes);
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updatedDate", createdDate);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public int SaveCoordinate(Coordinate coordinate, DateTime createdDate)
        {
            var sql = @"BEGIN	
	                        DECLARE @idCoordinate INT;	
	                        select @idCoordinate = c.Id from Coordinate c where c.Latitude = @latitude and c.Longitude = @longitude 
	                        
                            IF LEN(ISNULL(CAST(@idCoordinate AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO Coordinate (Longitude,Latitude,CreatedDate,UpdatedDate) OUTPUT Inserted.ID VALUES (@longitude, @latitude, @createdDate,@updateDate)
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
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updateDate", createdDate);
                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public int SaveWind(Wind wind, DateTime createdDate)
        {
            var sql = @"BEGIN	
	                        DECLARE @idWind INT;	
	                        select @idWind = w.Id from Wind w where w.Speed = @speed and w.Deg = @degree and w.Gust = @gust
	                        
                            IF LEN(ISNULL(CAST(@idWind AS varchar(50)),'')) = 0
	                        BEGIN		                        
		                        INSERT INTO Wind(Speed,Deg,Gust,CreatedDate,UpdatedDate) OUTPUT Inserted.ID VALUES (@speed, @degree, @gust, @createdDate, @updatedDate)
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
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updatedDate", createdDate);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public int SaveLocal(Local local, DateTime createdDate)
        {
            var sql = @"BEGIN
	                        DECLARE @idLocal INT;	
	                        SELECT @idLocal = l.Id FROM Local l WHERE l.Name = @name
	                        
                            IF LEN(ISNULL(CAST(@idLocal AS varchar(50)),'')) = 0
								BEGIN		                        
									INSERT INTO Local
									(Name
									,Timezone
									,CreatedDate
									,UpdatedDate)
									OUTPUT Inserted.Id
								VALUES
									(@name
									,@timezone									
									,@createdDate
									,@updatedDate)                                
								END
	                        ELSE
								BEGIN
									select @idLocal
								END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@name", local.Name);
                cmd.Parameters.AddWithValue("@timezone", local.Timezone);
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updatedDate", createdDate);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public int SaveAtmosphereConditions(AtmosphereConditions main, DateTime createdDate)
        {
            var sql = @"BEGIN
	                        DECLARE @idAtmospherCondition INT;

                            SELECT @idAtmospherCondition =Id 
                            FROM Atmosphere_condition a
                            WHERE a.FeelsLike = @feelsLike 
                              and a.Humidity = @humidity
                              and a.Pressure = @pressure
                              and a.Temp = @temp
                              and a.TempMin = @tempMin
                              and a.TempMax = @tempMax
	                        
                            IF LEN(ISNULL(CAST(@idAtmospherCondition AS varchar(50)),'')) = 0
								BEGIN		                        
									INSERT INTO Atmosphere_condition
                                           (Temp
                                           ,FeelsLike
                                           ,TempMin
                                           ,TempMax
                                           ,Pressure
                                           ,Humidity
                                           ,CreatedDate
                                           ,UpdatedDate)
                                          OUTPUT Inserted.Id	
                                     VALUES
                                           (@temp
                                           ,@feelsLike
                                           ,@tempMin
                                           ,@tempMax
                                           ,@pressure
                                           ,@humidity
                                           ,@createdDate
                                           ,@updatedDate)
								END
	                        ELSE
								BEGIN
									select @idAtmospherCondition
								END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@temp", main.Temp);
                cmd.Parameters.AddWithValue("@feelsLike", main.FeelsLike);
                cmd.Parameters.AddWithValue("@tempMin", main.TempMin);
                cmd.Parameters.AddWithValue("@tempMax", main.TempMax);
                cmd.Parameters.AddWithValue("@pressure", main.Pressure);
                cmd.Parameters.AddWithValue("@humidity", main.Humidity);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@updatedDate", DateTime.Now);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public int SaveSysAttributes(Sys sys, DateTime createdDate)
        {
            var sql = @"BEGIN
	                        DECLARE @idSys INT;

	                        SELECT @idSys = Id
                              FROM SysAttribute a
                              WHERE a.Sunrise = @sunrise
                              AND a.Sunset = @sunset
	                        
                            IF LEN(ISNULL(CAST(@idSys AS varchar(50)),'')) = 0
								BEGIN		                        
									INSERT INTO dbo.SysAttribute
                                           (Sunrise
                                           ,Sunset
                                           ,Country
                                           ,Type
                                           ,CreatedDate
                                           ,UpdateDate)
                                           OUTPUT Inserted.Id	
                                     VALUES                                            
                                           (@sunrise
                                           ,@sunset
                                           ,@country
                                           ,@type
                                           ,@createdDate
                                           ,@updatedDate)
								END
	                        ELSE
								BEGIN
									SELECT @idSys
								END	
                        END";

            var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@sunrise", sys.Sunrise);
                cmd.Parameters.AddWithValue("@sunset", sys.Sunset);
                cmd.Parameters.AddWithValue("@country", sys.Country);
                cmd.Parameters.AddWithValue("@type", sys.Type);
                cmd.Parameters.AddWithValue("@createdDate", createdDate);
                cmd.Parameters.AddWithValue("@updatedDate", createdDate);

                sqlConnection.Open();
                var result = (int)cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            };
        }
        public bool AttachCurrentLocalWeatherToWeather(int idCurrentLocalWeather, IList<int> idWeathers, DateTime createdDate)
        {
            try
            {
                foreach (var item in idWeathers)
                {
                    var sql = @"INSERT INTO Current_Local_Weather_Weather
                                   (Weather_Id
                                   ,Current_Local_Weather_Weather_Id
                                   ,CreatedDate
                                   ,UpdateDate)
                            VALUES
                                   (@weatherId
                                   ,@currentLocalWeatherId
                                   ,@createdDate
                                   ,@updatedDate)";

                    var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@currentLocalWeatherId", idCurrentLocalWeather);
                        cmd.Parameters.AddWithValue("@weatherId", item);
                        cmd.Parameters.AddWithValue("@createdDate", createdDate);
                        cmd.Parameters.AddWithValue("@updatedDate", createdDate);

                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                    };
                }
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }        
        public IPaginatedQuery<WeatherFromCityByDateDto> GetWeatherFromCityByDate(string cityName, string startDate, string finalDate)
        {
            var sql = @"SELECT l.Name AS CityName, 
                               w.Main AS WeatherDescription, 
                               w.Description AS SubDescription,
                               clw.CreatedDate AS CreatedDate 
                        FROM Current_Local_Weather c 
                            LEFT JOIN Local l ON c.Local_Id = l.Id 
                            LEFT JOIN Current_Local_Weather_Weather clw ON c.Id = clw.Current_Local_Weather_Weather_Id
                            LEFT JOIN Weather w ON clw.Weather_Id= w.Id  
                        WHERE clw.CreatedDate BETWEEN @startDate AND @finalDate
                            AND l.Name = @cityName";

            var parameters = new
            {
                cityName,
                startDate,
                finalDate
            };

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection)) 
            {
                var result = sqlConnection.Query<WeatherFromCityByDateDto>(sql, parameters, PaginationInfo.Default);
                return result;
            } 
        }
        public LastAverageTemperatureDto GetLastAverageTemperature() 
        {
            var sql = @"SELECT SUM(Temp)/COUNT(Id) as AverageTemp 
                        FROM (SELECT l.Name, a.Temp, c.Id, c.CreatedDate, ROW_NUMBER() OVER(PARTITION BY l.Name ORDER BY c.CreatedDate DESC ) AS rn FROM Current_Local_Weather c 
                        INNER JOIN Atmosphere_condition a ON c.Atmosphere_conditions_Id = a.Id
                        INNER JOIN Local l ON c.Local_Id = l.Id) AS T WHERE rn = 1";

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
            {
                var result = sqlConnection.QueryFirstOrDefault<LastAverageTemperatureDto>(sql);
                return result;
            }
        }
        public LastAverageTemperatureCityDto GetLastAverageTemperatureByCity(string city) 
        {
            var sql = @"SELECT SUM(Temp)/COUNT(Id) as AverageTemp, Name as CityName 
                        FROM (SELECT l.Name, a.Temp, c.Id, c.CreatedDate, ROW_NUMBER() OVER(PARTITION BY l.Name ORDER BY c.CreatedDate DESC ) AS rn FROM Current_Local_Weather c 
                        INNER JOIN Atmosphere_condition a ON c.Atmosphere_conditions_Id = a.Id
                        INNER JOIN Local l ON c.Local_Id = l.Id
						where l.Name = @city) AS T WHERE rn = 1 group by Name";

            var parameters = new
            {
                city
            };

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
            {
                var result = sqlConnection.QueryFirstOrDefault<LastAverageTemperatureCityDto>(sql, parameters);
                return result;
            }
        }
    }
}
