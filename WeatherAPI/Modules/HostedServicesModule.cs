using Autofac;
using WeatherAPI.Core.Common.HostedServices;
using WeatherAPI.HostedServices;

namespace WeatherAPI.Modules
{
    public class HostedServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<WeatherApiHostedService>().As<IWeatherApiHostedService>();
        }
    }
}
