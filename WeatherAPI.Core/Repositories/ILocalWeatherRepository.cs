using System.Collections.Generic;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Core.Repositories
{
    public interface ICurrentLocalWeatherRepository
    {
        public int SaveCurrentLocalWeather(int coordinateId, CurrentLocalWeather currentLocalWeatherDto);
    }
}
