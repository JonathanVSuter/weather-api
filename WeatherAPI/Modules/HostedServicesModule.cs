using Autofac;
using Microsoft.Extensions.Hosting;
using WeatherAPI.HostedServices;

namespace WeatherAPI.Modules
{
    public class HostedServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<WeatherApiHostedService>().As<IHostedService>().InstancePerDependency();
        }
    }
}
