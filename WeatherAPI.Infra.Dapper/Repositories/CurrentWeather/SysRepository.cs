using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Infra.Dapper.Repositories.CurrentWeather
{
    public class SysRepository : ISysRepository
    {
        public int SaveSys(Sys sys)
        {
            throw new NotImplementedException();
        }
    }
}
