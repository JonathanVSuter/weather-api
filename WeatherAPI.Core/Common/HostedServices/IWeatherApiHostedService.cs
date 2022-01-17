using Microsoft.Extensions.Hosting;
using System;

namespace WeatherAPI.Core.Common.HostedServices
{
    public interface IWeatherApiHostedService : IHostedService, IDisposable
    {
        void GetDataFromWeatherApi(object state);
    }
}
