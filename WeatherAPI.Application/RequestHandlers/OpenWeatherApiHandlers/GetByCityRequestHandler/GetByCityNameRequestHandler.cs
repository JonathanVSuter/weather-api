using System.Threading.Tasks;
using WeatherAPI.Core.Common.RequestHandler;
using WeatherAPI.Core.Requests;
using WeatherAPI.Core.Services.OpenWeather;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Application.RequestHandlers.OpenWeatherApiHandlers.GetByCityRequestHandler
{
    public class GetByCityNameRequestHandler : IRequestHandler<GetByCityNameRequest, CurrentLocalWeatherDto>
    {
        private readonly IOpenWeatherApiServiceGetCurrent _openWeatherApiService;
        public GetByCityNameRequestHandler(IOpenWeatherApiServiceGetCurrent openWeatherApiService)
        {
            _openWeatherApiService = openWeatherApiService;
        }
        public async Task<CurrentLocalWeatherDto> Execute(GetByCityNameRequest query)
        {
            return await _openWeatherApiService.GetByCityName(query.City).ConfigureAwait(true);
        }
    }
}
