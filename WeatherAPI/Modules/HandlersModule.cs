using Autofac;
using System.Collections.Generic;
using WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers;
using WeatherAPI.Application.QueryHandlers.OpenWeatherApiQueryHandlers;
using WeatherAPI.Application.RequestHandlers.OpenWeatherApiHandlers.GetByCityRequestHandler;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Common.Pagination;
using WeatherAPI.Core.Common.QueryHandler;
using WeatherAPI.Core.Common.RequestHandler;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Requests;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Modules
{
    public class HandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<GetByCityNameRequestHandler>().As<IRequestHandler<GetByCityNameRequest, CurrentLocalWeatherDto>>();
            builder.RegisterType<GetByCityNameCurrentWeatherCommandHandler>().As<ICommandHandler<GetByCityNameCurrentWeatherCommand>>();
            builder.RegisterType<GetWeatherFromCityByDateQueryHandler>().As<IQueryHandler<GetWeatherFromCityByDateQuery, IPaginatedQuery<WeatherFromCityByDateDto>>>();
        }
    }
}
