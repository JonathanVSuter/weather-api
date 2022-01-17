using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;

namespace WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers
{
    public class GetByCityNameCurrentWeatherCommandHandler : ICommandHandler<GetByCityNameCurrentWeatherCommand>
    {
        //desenvolver a repository e fazer as injeções necessárias

        public void Handle(GetByCityNameCurrentWeatherCommand command)
        {

        }
    }
}
