using Autofac;
using WeatherAPI.Core.Repositories;
using WeatherAPI.Infra.Dapper.Repositories.CurrentWeather;

namespace WeatherAPI.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<CurrentWeatherRepository>().As<ICurrentWeatherRepository>();
        }
    }
}
