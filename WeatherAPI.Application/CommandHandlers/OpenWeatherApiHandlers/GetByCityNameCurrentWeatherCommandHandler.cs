using System;
using System.Collections.Generic;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers
{
    public class GetByCityNameCurrentWeatherCommandHandler : ICommandHandler<GetByCityNameCurrentWeatherCommand>
    {
        private readonly ICurrentWeatherRepository _currentLocalWeatherRepository;
        public GetByCityNameCurrentWeatherCommandHandler(ICurrentWeatherRepository currentLocalWeatherRepository)
        {
            _currentLocalWeatherRepository = currentLocalWeatherRepository;
        }

        public void Handle(GetByCityNameCurrentWeatherCommand command)
        {
            DateTime registerDate = DateTime.Now;

            var cloudId = _currentLocalWeatherRepository.SaveCloud(command.CurrentLocalWeather.Clouds, registerDate);
            var coordinateId = _currentLocalWeatherRepository.SaveCoordinate(command.CurrentLocalWeather.Coord, registerDate);
            var windId = _currentLocalWeatherRepository.SaveWind(command.CurrentLocalWeather.Wind, registerDate);
            var sysId = _currentLocalWeatherRepository.SaveSysAttributes(command.CurrentLocalWeather.Sys, registerDate);
            var atmosphereConditionsId = _currentLocalWeatherRepository.SaveAtmosphereConditions(command.CurrentLocalWeather.AtmosphereConditions, registerDate);
            var localId = _currentLocalWeatherRepository.SaveLocal(command.CurrentLocalWeather.Local, registerDate);
            var currentLocalWeatherId = _currentLocalWeatherRepository.SaveCurrentLocalWeather(localId,cloudId,windId,coordinateId,sysId,atmosphereConditionsId,registerDate);

            IList<int> weatherIds = new List<int>();

            foreach (var weather in command.CurrentLocalWeather.Weather)
                weatherIds.Add(_currentLocalWeatherRepository.SaveWeather(weather, registerDate));

            var attachCurrentWeatherToWeather = _currentLocalWeatherRepository.AttachCurrentLocalWeatherToWeather(currentLocalWeatherId, weatherIds, registerDate);

        }
    }
}
