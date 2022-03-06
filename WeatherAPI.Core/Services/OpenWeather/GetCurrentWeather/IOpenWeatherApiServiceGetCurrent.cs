using System.Threading.Tasks;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Core.Services.OpenWeather
{
    public interface IOpenWeatherApiServiceGetCurrent
    {
        Task<CurrentLocalWeatherDto> GetByCityName(string city);
        CurrentLocalWeatherDto GetByCityAndState(string city, string state);
        CurrentLocalWeatherDto GetByCityStateAndCountryCode(string city, string state, string countryCode);
        CurrentLocalWeatherDto GetByCityId(string id);
        CurrentLocalWeatherDto GetByGeoCoordinates(string latitude, string longitude);
        CurrentLocalWeatherDto GetByZipCode(string zipCode);
    }
}
