using Autofac;
using WeatherAPI.Controllers;

namespace WeatherAPI.Modules
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ValuesController>().PropertiesAutowired();
        }
    }

}
