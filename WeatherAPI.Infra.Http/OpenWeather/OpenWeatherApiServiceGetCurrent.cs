using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI.Core.Configuration;
using WeatherAPI.Core.Services.OpenWeather;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather;
using WeatherAPI.Infra.Http.Extensions;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Object;

namespace WeatherAPI.Infra.Http.OpenWeather
{
    public class OpenWeatherApiServiceGetCurrent : IOpenWeatherApiServiceGetCurrent
    {
        private readonly IOptions<ApiConfiguration> _options;

        public OpenWeatherApiServiceGetCurrent(IOptions<ApiConfiguration> options)
        {
            _options = options;
        }
        public async Task<CurrentLocalWeatherDto> GetByCityName(string city)
        {
            HttpResponseMessage httpResponseMessage;

            using (var client = ApiExtensions.CreateHttpClient(_options.Value.APIWeatherBaseAdress))
            {
                httpResponseMessage = await client.GetAsync($"weather?q={city}&appid={_options.Value.Token}").ConfigureAwait(true);
            }

            var json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);
            var weather = JsonConvert.DeserializeObject<GetCurrentWeatherObject>(json);

            return weather.AsDto();
        }

        public CurrentLocalWeatherDto GetByCityAndState(string city, string state)
        {
            throw new NotImplementedException();
        }

        public CurrentLocalWeatherDto GetByCityId(string id)
        {
            throw new NotImplementedException();
        }

        public CurrentLocalWeatherDto GetByCityStateAndCountryCode(string city, string state, string countryCode)
        {
            throw new NotImplementedException();
        }

        public CurrentLocalWeatherDto GetByGeoCoordinates(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public CurrentLocalWeatherDto GetByZipCode(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
}
