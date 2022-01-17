using Autofac;
using System;
using WeatherAPI.Core.Common.InfraOperations;

namespace WeatherAPI.Application.BaseOperations
{
    public class AsyncRunner : IAsyncRunner
    {
        public ILifetimeScope LifetimeScope { get; set; }

        public AsyncRunner(ILifetimeScope lifetimeScope)
        {
            if (lifetimeScope == null) throw new ArgumentException("LifetimeScope");
            LifetimeScope = lifetimeScope;
        }
        public void Run<T>(Action<T> action)
        {
            //TODO 
            throw new NotImplementedException();
        }
    }
}
