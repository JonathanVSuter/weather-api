﻿using System.Collections.Generic;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Core.Repositories
{
    public interface ICurrentWeatherRepository
    {
        public int SaveCurrentLocalWeather(int coordinateId, CurrentLocalWeather currentLocalWeather);
        public int SaveCloud(Cloud clouds);
        public int SaveWeather(Weather weather);
        public int SaveWind(Wind wind);
        public int SaveCoordinate(Coordinate coordinate);
        void AttachLocalToWeather(int idLocal, IList<int> idWeathers);
        void AttachLocalToWind(int idLocal, int idWind);
        void AttachLocalToCloud(int idLocal, int idCloud);
    }
}
