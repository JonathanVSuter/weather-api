using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Queries.OpenWeatherApi
{
    public class LastAverageTemperatureCityDto
    {
        public string CityName { get; set; }
        public double AverageTemp { get; set; }
    }
}
