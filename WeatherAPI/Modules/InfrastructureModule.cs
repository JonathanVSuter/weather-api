using Autofac;
using WeatherAPI.Application.BaseOperations;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Infra.Dapper.TransactionManagement;

namespace WeatherAPI.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DbSession>().As<IDbSession>().InstancePerLifetimeScope();
            builder.RegisterType<QueryExecutor>().As<IQueryExecutor>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
            builder.RegisterType<RequestExecutor>().As<IRequestExecutor>().InstancePerLifetimeScope();
        }
    }
}
