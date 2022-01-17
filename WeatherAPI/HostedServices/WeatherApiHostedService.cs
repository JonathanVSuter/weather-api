using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.Core.Commands.OpenWeatherApiCommands;
using WeatherAPI.Core.Common.HostedServices;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Requests;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.HostedServices
{
    public class WeatherApiHostedService : IWeatherApiHostedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IRequestExecutor _requestExecutor;
        private readonly TimeSpan _timeSpanTask = TimeSpan.FromMinutes(15); 
        public WeatherApiHostedService(IUnitOfWork unitOfWork, ICommandDispatcher commandDispatcher, IRequestExecutor requestExecutor)
        {
            _unitOfWork = unitOfWork;
            _commandDispatcher = commandDispatcher;
            _requestExecutor = requestExecutor;
        }
        public WeatherApiHostedService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        public async void GetDataFromWeatherApi(object state)
        {
            var request = new GetByCityNameRequest("Florianopolis");

            var response = await _requestExecutor.ExecuteRequest<GetByCityNameRequest, CurrentLocalWeatherDto>(request).ConfigureAwait(true);

            var command = new GetByCityNameCurrentWeatherCommand(response.AsBusiness());





        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(GetDataFromWeatherApi, null, TimeSpan.Zero, _timeSpanTask);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //TODO
        }
    }
}
