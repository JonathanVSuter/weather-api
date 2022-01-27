using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherAPI.Application.BaseOperations;
using WeatherAPI.Application.CommandHandlers.OpenWeatherApiHandlers;
using WeatherAPI.Application.RequestHandlers.OpenWeatherApiHandlers.GetByCityRequestHandler;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Common.RequestHandler;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Core.Requests;
using WeatherAPI.Core.Services.OpenWeather;
using WeatherAPI.HostedServices;
using WeatherAPI.Infra.Dapper.Repositories.CurrentWeather;
using WeatherAPI.Infra.Dapper.TransactionManagement;
using WeatherAPI.Infra.Http.OpenWeather;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                //adjust to use modules
                //.ConfigureContainer<ContainerBuilder>(builder =>
                //{
                //    builder.RegisterType<InfrastructureModule>();
                //    builder.RegisterType<HostedServicesModule>();
                //    builder.RegisterType<ServicesModule>();
                //})
                .ConfigureServices(services =>
                {
                    services.AddScoped<IOpenWeatherApiServiceGetCurrent, OpenWeatherApiServiceGetCurrent>();
                    services.AddTransient<IQueryExecutor, QueryExecutor>();
                    services.AddTransient<IUnitOfWork, UnitOfWork>();
                    services.AddTransient<ICommandDispatcher, CommandDispatcher>();
                    services.AddTransient<IRequestExecutor, RequestExecutor>();
                    services.AddScoped<IRequestHandler<GetByCityNameRequest, CurrentLocalWeatherDto>, GetByCityNameRequestHandler>();
                    services.AddScoped<ICommandHandler<GetByCityNameCurrentWeatherCommand>, GetByCityNameCurrentWeatherCommandHandler>();
                    services.AddScoped<ICurrentWeatherRepository, CurrentWeatherRepository>();
                    services.AddScoped<IDbSession,DbSession>();
                    services.AddHostedService<WeatherApiHostedService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
