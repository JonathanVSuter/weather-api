using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.Queries;
using WeatherAPI.Core.Exceptions.Business;

namespace WeatherAPI.Core.Queries.OpenWeatherApi
{
    public class GetWeatherFromCityByDateQuery :IQuery<IEnumerable<WeatherFromCityByDateDto>>
    {
        public string CityName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }

        public GetWeatherFromCityByDateQuery(string cityName, DateTime startDate, DateTime finalDate) 
        {
            if (string.IsNullOrEmpty(cityName)) throw new BusinessException("City name should be informed.");            

            CityName = cityName;
            StartDate = startDate;
            FinalDate = finalDate;
        }
    }
}
