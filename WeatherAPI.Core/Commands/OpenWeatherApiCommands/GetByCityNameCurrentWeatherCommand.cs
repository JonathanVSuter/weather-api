using WeatherAPI.Core.Common.Command;
using WeatherAPI.Core.Exceptions.Business;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Core.Commands.OpenWeatherApiCommands
{
    public class GetByCityNameCurrentWeatherCommand : ICommand
    {
        public CurrentLocalWeather CurrentLocalWeather { get; set; }

        public GetByCityNameCurrentWeatherCommand(CurrentLocalWeather currentLocalWeather)
        {
            if (currentLocalWeather is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather)} is null");
            if (currentLocalWeather.Clouds is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather.Clouds)} is null");
            if (currentLocalWeather.Coord is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather.Coord)} is null");
            if (currentLocalWeather.AtmosphereConditions is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather.AtmosphereConditions)} is null");
            if (currentLocalWeather.Sys is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather.Sys)} is null");
            if (currentLocalWeather.Wind is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather.Wind)} is null");
            if (currentLocalWeather.Weather is null)
                throw new BusinessException($"Parameter {nameof(currentLocalWeather.Weather)} is null");

            CurrentLocalWeather = currentLocalWeather;
        }
    }
}
