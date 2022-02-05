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
            var cloudId = _currentLocalWeatherRepository.SaveCloud(command.CurrentLocalWeather.Clouds);
            var coordinateId = _currentLocalWeatherRepository.SaveCoordinate(command.CurrentLocalWeather.Coord);
            var windId = _currentLocalWeatherRepository.SaveWind(command.CurrentLocalWeather.Wind);
            IList<int> weatherIds = new List<int>();

            foreach (var weather in command.CurrentLocalWeather.Weather)
                weatherIds.Add(_currentLocalWeatherRepository.SaveWeather(weather));

            var localId = _currentLocalWeatherRepository.SaveCurrentLocalWeather(coordinateId, command.CurrentLocalWeather);

            //add unitOfWork state

            _currentLocalWeatherRepository.AttachLocalToOthers(localId, cloudId, windId, weatherIds);

            //_currentLocalWeatherRepository.AttachLocalToCloud(localId, cloudId);

            //_currentLocalWeatherRepository.AttachLocalToWeather(localId, weatherIds);

            //_currentLocalWeatherRepository.AttachLocalToWind(localId, windId);

        }
    }
}
