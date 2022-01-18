using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Core.Repositories
{
    public interface IWindRepository
    {
        public int SaveWind(Wind wind);
    }
}
