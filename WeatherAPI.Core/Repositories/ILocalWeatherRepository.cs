using System;
using System.Collections.Generic;
using WeatherAPI.Core.Common.Pagination;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Core.Repositories
{
    public interface ICurrentWeatherRepository
    {
        public int SaveLocal(Local local, DateTime createdDate);
        public int SaveCurrentLocalWeather(int idLocal, int idCloud, int idWind, int idCoordinate, int idSysAttributes, int idAtmosphereConditions, DateTime createdDate);
        public int SaveCloud(Cloud clouds, DateTime createdDate);
        public int SaveWeather(Weather weather, DateTime createdDate);
        public int SaveWind(Wind wind, DateTime createdDate);
        public int SaveCoordinate(Coordinate coordinate, DateTime createdDate);
        public int SaveAtmosphereConditions(AtmosphereConditions main, DateTime createdDate);
        public int SaveSysAttributes(Sys sys, DateTime createdDate);
        public bool AttachCurrentLocalWeatherToWeather(int idCurrentLocalWeather, IList<int> idWeathers, DateTime createdDate);        
        public IPaginatedQuery<WeatherFromCityByDateDto> GetWeatherFromCityByDate(string cityName, string startDate, string finalDate);
    }
}
