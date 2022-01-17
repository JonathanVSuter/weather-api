
using Autofac;
using WeatherAPI.Core.Services.OpenWeather;
using WeatherAPI.Infra.Http.OpenWeather;

namespace WeatherAPI.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<OpenWeatherApiServiceGetCurrent>().As<IOpenWeatherApiServiceGetCurrent>();
        }
    }
}
