using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Core.Repositories
{
    public interface IWeatherRepository
    {
        public int SaveWeather(Weather weather);
    }
}
