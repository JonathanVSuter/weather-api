using Autofac;
using WeatherAPI.Application.BaseOperations;
using WeatherAPI.Core.Common.InfraOperations;

namespace WeatherAPI.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
        }
    }
}
