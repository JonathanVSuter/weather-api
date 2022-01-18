using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Repositories
{
    public interface ICurrentLocalWeatherRepository
    {
        public bool SaveCurrenLocaltWeather();
    }
}
