using System;
using System.Threading.Tasks;
using WeatherAPI.Core.Common.Requests;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Core.Requests
{
    public class GetByCityNameRequest : IRequest<Task<CurrentLocalWeatherDto>>
    {
        public string City { get; set; }

        public GetByCityNameRequest(string city)
        {
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));

            City = city;
        }
    }
}
