using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

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
        //public async Task<bool> AttachLocalToOthers(int idLocal, int idCloud, int idWind, IList<int> idWeathers) 
        //{
        //    DateTime created = DateTime.Now;
        //    try
        //    {
        //        _unitOfWork.BeginTransaction();

        //        var sql = @"INSERT INTO [dbo].[Local_Cloud]
        //                           ([fk_Local_Id]
        //                           ,[fk_Cloud_Id]
        //                           ,[CreatedAt]
        //                           ,[LastUpdate])
        //                     VALUES
        //                           (@idLocal
        //                           ,@idCloud
        //                           ,@createdAt
        //                           ,@lastUpdate)";                

        //        using (SqlCommand cmd = new SqlCommand(sql, _unitOfWork._session.Connection, _unitOfWork._session.Transaction))
        //        {
        //            cmd.Parameters.Add("@idLocal", System.Data.SqlDbType.Int);
        //            cmd.Parameters.Add("@idCloud", System.Data.SqlDbType.Int);
        //            cmd.Parameters.Add("@createdAt", System.Data.SqlDbType.DateTime);
        //            cmd.Parameters.Add("@lastUpdate", System.Data.SqlDbType.DateTime);

        //            cmd.Parameters["@idLocal"].Value = idLocal;
        //            cmd.Parameters["@idCloud"].Value = idCloud;
        //            cmd.Parameters["@createdAt"].Value = created;
        //            cmd.Parameters["@lastUpdate"].Value = created;

        //            await cmd.ExecuteNonQueryAsync().ConfigureAwait(true);

        //        };

        //        sql = @"INSERT INTO [dbo].[Local_Weather]
        //                       ([fk_Local_Id]
        //                       ,[fk_Weather_Id]
        //                       ,[createdAt]
        //                       ,[updatedAt])
        //                 VALUES
        //                       (@idLocal
        //                       ,@idWeather
        //                       ,@createdAt
        //                       ,@lastUpdate)";

        //        foreach (var idWeather in idWeathers)
        //        {

        //            using (SqlCommand cmd = new SqlCommand(sql, _unitOfWork._session.Connection, _unitOfWork._session.Transaction))
        //            {
        //                cmd.Parameters.Add("@idLocal", System.Data.SqlDbType.Int);
        //                cmd.Parameters.Add("@idWeather", System.Data.SqlDbType.Int);
        //                cmd.Parameters.Add("@createdAt", System.Data.SqlDbType.DateTime);
        //                cmd.Parameters.Add("@lastUpdate", System.Data.SqlDbType.DateTime);

        //                cmd.Parameters["@idLocal"].Value = idLocal;
        //                cmd.Parameters["@idWeather"].Value = idWeather;
        //                cmd.Parameters["@createdAt"].Value = created;
        //                cmd.Parameters["@lastUpdate"].Value = created;

        //                await cmd.ExecuteNonQueryAsync().ConfigureAwait(true);
        //            };
        //        }

        //        sql = @"INSERT INTO [dbo].[Local_Wind]
        //                           ([fk_Local_Id]
        //                           ,[fk_Wind_Id]
        //                           ,[CreatedAt]
        //                           ,[LastUpdate])
        //                     VALUES
        //                           (@idLocal
        //                           ,@idWind
        //                           ,@createdAt
        //                           ,@lastUpdate)";

        //        using (SqlCommand cmd = new SqlCommand(sql, _unitOfWork._session.Connection, _unitOfWork._session.Transaction))
        //        {
        //            cmd.Parameters.Add("@idLocal", System.Data.SqlDbType.Int);
        //            cmd.Parameters.Add("@idWind", System.Data.SqlDbType.Int);
        //            cmd.Parameters.Add("@createdAt", System.Data.SqlDbType.DateTime);
        //            cmd.Parameters.Add("@lastUpdate", System.Data.SqlDbType.DateTime);

        //            cmd.Parameters["@idLocal"].Value = idLocal;
        //            cmd.Parameters["@idWind"].Value = idWind;
        //            cmd.Parameters["@createdAt"].Value = created;
        //            cmd.Parameters["@lastUpdate"].Value = created;

        //            await cmd.ExecuteNonQueryAsync().ConfigureAwait(true);
        //        };

        //        await _unitOfWork.CommitAsync().ConfigureAwait(true);

        //        return true;
        //    }
        //    catch(SqlException ex) 
        //    {
        //        Debug.WriteLine($"Error: {ex.Message}");
        //        _unitOfWork.Rollback();
        //        return true;
        //    }           
        //}
        public void AttachLocalToOthers(int idLocal, int idCloud, int idWind, IList<int> idWeathers)
        {
            DateTime created = DateTime.Now;
            try
            {
                _unitOfWork.BeginTransaction();

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

                using (SqlCommand cmd = new SqlCommand(sql, _unitOfWork._session.Connection, _unitOfWork._session.Transaction))
                {
                    cmd.Parameters.Add("@idLocal", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@idCloud", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@createdAt", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@lastUpdate", System.Data.SqlDbType.DateTime);

                    cmd.Parameters["@idLocal"].Value = idLocal;
                    cmd.Parameters["@idCloud"].Value = idCloud;
                    cmd.Parameters["@createdAt"].Value = created;
                    cmd.Parameters["@lastUpdate"].Value = created;

                    cmd.ExecuteNonQuery();

                };

                sql = @"INSERT INTO [dbo].[Local_Weather]
                               ([fk_Local_Id]
                               ,[fk_Weather_Id]
                               ,[createdAt]
                               ,[updatedAt])
                         VALUES
                               (@idLocal
                               ,@idWeather
                               ,@createdAt
                               ,@lastUpdate)";

                foreach (var idWeather in idWeathers)
                {

                    using (SqlCommand cmd = new SqlCommand(sql, _unitOfWork._session.Connection, _unitOfWork._session.Transaction))
                    {
                        cmd.Parameters.Add("@idLocal", System.Data.SqlDbType.Int);
                        cmd.Parameters.Add("@idWeather", System.Data.SqlDbType.Int);
                        cmd.Parameters.Add("@createdAt", System.Data.SqlDbType.DateTime);
                        cmd.Parameters.Add("@lastUpdate", System.Data.SqlDbType.DateTime);

                        cmd.Parameters["@idLocal"].Value = idLocal;
                        cmd.Parameters["@idWeather"].Value = idWeather;
                        cmd.Parameters["@createdAt"].Value = created;
                        cmd.Parameters["@lastUpdate"].Value = created;

                        cmd.ExecuteNonQuery();
                    };
                }

                sql = @"INSERT INTO [dbo].[Local_Wind]
                                   ([fk_Local_Id]
                                   ,[fk_Wind_Id]
                                   ,[CreatedAt]
                                   ,[LastUpdate])
                             VALUES
                                   (@idLocal
                                   ,@idWind
                                   ,@createdAt
                                   ,@lastUpdate)";

                using (SqlCommand cmd = new SqlCommand(sql, _unitOfWork._session.Connection, _unitOfWork._session.Transaction))
                {
                    cmd.Parameters.Add("@idLocal", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@idWind", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@createdAt", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@lastUpdate", System.Data.SqlDbType.DateTime);

                    cmd.Parameters["@idLocal"].Value = idLocal;
                    cmd.Parameters["@idWind"].Value = idWind;
                    cmd.Parameters["@createdAt"].Value = created;
                    cmd.Parameters["@lastUpdate"].Value = created;

                    cmd.ExecuteNonQuery();
                };

                _unitOfWork.Commit();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                _unitOfWork.Rollback();
            }
        }

        public IEnumerable<WeatherFromCityByDateDto> GetWeatherFromCityByDate(string cityName, string startDate, string finalDate)
        {
            var sql = @"SELECT l.Name as CityName,
                        lw.createdAt as CreatedDate,
                        w.Main as WeatherDescription,
                        w.Description SubDescription
                        FROM Local l 
                        LEFT JOIN Local_Weather lw ON l.Id = lw.fk_Local_Id
                        LEFT JOIN Weather w ON lw.fk_Weather_Id = w.Id
                        WHERE l.Name = @cityName 
                        AND (lw.createdAt >= @startDate AND lw.createdAt <= @finalDate)";

            var parameters = new
            {
                cityName,
                startDate,
                finalDate
            };

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection)) 
            {
                var result = sqlConnection.Query<WeatherFromCityByDateDto>(sql, parameters);
                return result;
            } 
        }
        //private void AttachLocalToCloud(int idLocal, int idCloud)
        //{
        //    var sql = @"INSERT INTO [dbo].[Local_Cloud]
        //                           ([fk_Local_Id]
        //                           ,[fk_Cloud_Id]
        //                           ,[CreatedAt]
        //                           ,[LastUpdate])
        //                     VALUES
        //                           (@idLocal
        //                           ,@idCloud
        //                           ,@createdAt
        //                           ,@lastUpdate)";

        //    var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
        //    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
        //    {
        //        cmd.Parameters.AddWithValue("@idLocal", idLocal);
        //        cmd.Parameters.AddWithValue("@idCloud", idCloud);
        //        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
        //        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);

        //        sqlConnection.Open();
        //        cmd.ExecuteScalar();
        //        sqlConnection.Close();
        //    };
        //}
        //private void AttachLocalToWeather(int idLocal, IList<int> idWeathers)
        //{
        //    var sql = @"INSERT INTO [dbo].[Local_Weather]
        //                       ([fk_Local_Id]
        //                       ,[fk_Weather_Id]
        //                       ,[createdAt]
        //                       ,[updatedAt])
        //                 VALUES
        //                       (@idLocal
        //                       ,@idWeather
        //                       ,@createdAt
        //                       ,@lastUpdate)";

        //    var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);

        //    foreach (var idWeather in idWeathers)
        //    {

        //        using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
        //        {
        //            cmd.Parameters.AddWithValue("@idLocal", idLocal);
        //            cmd.Parameters.AddWithValue("@idWeather", idWeather);
        //            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
        //            cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);

        //            sqlConnection.Open();
        //            cmd.ExecuteScalar();
        //            sqlConnection.Close();
        //        };
        //    }
        //}
        //private void AttachLocalToWind(int idLocal, int idWind)
        //{
        //    var sql = @"INSERT INTO [dbo].[Local_Wind]
        //                           ([fk_Local_Id]
        //                           ,[fk_Wind_Id]
        //                           ,[CreatedAt]
        //                           ,[LastUpdate])
        //                     VALUES
        //                           (@idLocal
        //                           ,@idWind
        //                           ,@createdAt
        //                           ,@lastUpdate)";

        //    var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection);
        //    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
        //    {
        //        cmd.Parameters.AddWithValue("@idLocal", idLocal);
        //        cmd.Parameters.AddWithValue("@idWind", idWind);
        //        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
        //        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);

        //        sqlConnection.Open();
        //        cmd.ExecuteScalar();
        //        sqlConnection.Close();
        //    };
        //}
    }
}
