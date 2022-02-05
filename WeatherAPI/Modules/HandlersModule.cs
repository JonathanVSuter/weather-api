using Autofac;
using WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers;
using WeatherAPI.Application.RequestHandlers.OpenWeatherApiHandlers.GetByCityRequestHandler;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Common.RequestHandler;
using WeatherAPI.Core.Requests;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Modules
{
    public class HandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<GetByCityNameRequestHandler>().As<IRequestHandler<GetByCityNameRequest, CurrentLocalWeatherDto>>();
            builder.RegisterType<GetByCityNameCurrentWeatherCommandHandler>().As<ICommandHandler<GetByCityNameCurrentWeatherCommand>>();
        }
    }
}
