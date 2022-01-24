using System.Collections.Generic;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers
{
    public class GetByCityNameCurrentWeatherCommandHandler : ICommandHandler<GetByCityNameCurrentWeatherCommand>
    {
        private readonly ICloudRepository _cloudRepository;
        private readonly ICoordinateRepository _coordinateRepository;
        private readonly IWindRepository _windRepository;
        private readonly IWeatherRepository _weatherRepository;
        private readonly ICurrentLocalWeatherRepository _currentLocalWeatherRepository;
        private readonly IWeatherRelationshipsFinisherRepository _weatherRelationshipsFinisherRepository;


        public GetByCityNameCurrentWeatherCommandHandler(ICloudRepository cloudRepository, ICoordinateRepository coordinateRepository, IWindRepository windRepository, 
                                                         IWeatherRepository weatherRepository, ICurrentLocalWeatherRepository currentLocalWeatherRepository, IWeatherRelationshipsFinisherRepository weatherRelationshipsFinisherRepository) 
        {
            _cloudRepository = cloudRepository;
            _coordinateRepository = coordinateRepository;
            _windRepository = windRepository;
            _weatherRepository = weatherRepository;
            _currentLocalWeatherRepository = currentLocalWeatherRepository;
            _weatherRelationshipsFinisherRepository = weatherRelationshipsFinisherRepository;
        }

        public void Handle(GetByCityNameCurrentWeatherCommand command)
        {   
            var cloudId =_cloudRepository.SaveCloud(command.CurrentLocalWeather.Clouds);
            var coordinateId = _coordinateRepository.SaveCoordinate(command.CurrentLocalWeather.Coord);
            var windId = _windRepository.SaveWind(command.CurrentLocalWeather.Wind);
            IList<int> weatherIds = new List<int>();

            foreach (var weather in command.CurrentLocalWeather.Weather)
                weatherIds.Add(_weatherRepository.SaveWeather(weather));

            var localId = _currentLocalWeatherRepository.SaveCurrentLocalWeather(coordinateId, command.CurrentLocalWeather);

            _weatherRelationshipsFinisherRepository.SaveLocalCloud(localId, cloudId);

            _weatherRelationshipsFinisherRepository.SaveLocalWeather(localId, weatherIds);

            _weatherRelationshipsFinisherRepository.SaveLocalWind(localId, windId);

        }
    }
}
