using System;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IAsyncRunner
    {
        void Run<T>(Action<T> action);
    }
}
