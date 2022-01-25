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
    //public class WeatherApiHostedService : BackgroundService
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ICommandDispatcher _commandDispatcher;
    //    private readonly IRequestExecutor _requestExecutor;
    //    private readonly TimeSpan _timeSpanTask = TimeSpan.FromSeconds(20);
    //    public WeatherApiHostedService(IUnitOfWork unitOfWork, ICommandDispatcher commandDispatcher, IRequestExecutor requestExecutor)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _commandDispatcher = commandDispatcher;
    //        _requestExecutor = requestExecutor;
    //    }
    //    public WeatherApiHostedService(IRequestExecutor requestExecutor)
    //    {
    //        _requestExecutor = requestExecutor;
    //    }
    //    public async Task GetDataFromWeatherApi()
    //    {
    //        try
    //        {
    //            var request = new GetByCityNameRequest("Florianopolis");

    //            var response = await _requestExecutor.ExecuteRequest<GetByCityNameRequest, CurrentLocalWeatherDto>(request).ConfigureAwait(true);

    //            var command = new GetByCityNameCurrentWeatherCommand(response.AsBusiness());

    //            _commandDispatcher.Dispatch(command);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        while (!stoppingToken.IsCancellationRequested) 
    //        {
    //            await GetDataFromWeatherApi();
    //            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
    //        }
    //    }
    //}
    public class WeatherApiHostedService : IWeatherApiHostedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IRequestExecutor _requestExecutor;
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
        public async void GetDataFromWeatherApi()
        {
            try
            {
                var request = new GetByCityNameRequest("Florianópolis");

                await _requestExecutor.ExecuteRequest<GetByCityNameRequest, CurrentLocalWeatherDto>(request).ContinueWith(response =>
                {
                    var command = new GetByCityNameCurrentWeatherCommand(response.Result.AsBusiness());

                    _commandDispatcher.Dispatch(command);

                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                GetDataFromWeatherApi();
                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
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
