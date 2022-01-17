using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherAPI.Application.BaseOperations;
using WeatherAPI.Application.RequestHandlers.OpenWeatherApiHandlers.GetByCityRequestHandler;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Common.RequestHandler;
using WeatherAPI.Core.Requests;
using WeatherAPI.Core.Services.OpenWeather;
using WeatherAPI.HostedServices;
using WeatherAPI.Infra.Http.OpenWeather;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;
using WeatherAPI.Modules;

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
                //ajustar para usar os módulos
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterType<InfrastructureModule>();
                    builder.RegisterType<HostedServicesModule>();
                    builder.RegisterType<ServicesModule>();
                })
                .ConfigureServices(services =>
                {
                    //assim funcionou
                    services.AddScoped<IOpenWeatherApiServiceGetCurrent, OpenWeatherApiServiceGetCurrent>();
                    services.AddTransient<IQueryExecutor, QueryExecutor>();
                    services.AddTransient<IUnitOfWork, UnitOfWork>();
                    services.AddTransient<ICommandDispatcher, CommandDispatcher>();
                    services.AddTransient<IRequestExecutor, RequestExecutor>();
                    services.AddScoped<IRequestHandler<GetByCityNameRequest, CurrentLocalWeatherDto>, GetByCityNameRequestHandler>();
                    services.AddHostedService<WeatherApiHostedService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
