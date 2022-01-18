using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Repositories
{
    public interface IWeatherRepository
    {
        public int SaveWeather();
    }
}
