using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.Queries;

namespace WeatherAPI.Core.Queries.OpenWeatherApi
{
    public class GetLastAverageTemperatureByCityQuery : IQuery<LastAverageTemperatureCityDto>
    {
        public string City { get; set; }

        public GetLastAverageTemperatureByCityQuery(string city)
        {
            City = city;
        }
    }
}
