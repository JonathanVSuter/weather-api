using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers
{
    public class GetByCityNameCurrentWeatherCommandHandler : ICommandHandler<GetByCityNameCurrentWeatherCommand>
    {
        private readonly ICloudRepository _cloudRepository;

        public GetByCityNameCurrentWeatherCommandHandler(ICloudRepository cloudRepository) 
        {
            _cloudRepository = cloudRepository;
        }

        public void Handle(GetByCityNameCurrentWeatherCommand command)
        {
            _cloudRepository.SaveCloudRepository(command.CurrentLocalWeather.Clouds);
        }
    }
}
