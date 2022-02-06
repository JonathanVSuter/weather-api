using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Queries.OpenWeatherApi
{
    public class WeatherFromCityByDateDto
    {
        public string CityName { get; set; }
        public string CreatedDate { get; set; }
        public string WeatherDescription { get; set; }
        public string SubDescription { get; set; }
    }
}
