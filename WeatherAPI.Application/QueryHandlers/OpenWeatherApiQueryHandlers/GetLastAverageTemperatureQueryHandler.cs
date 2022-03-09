using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.QueryHandler;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.QueryHandlers.OpenWeatherApiQueryHandlers
{
    public class GetLastAverageTemperatureQueryHandler : IQueryHandler<GetLastAverageTemperatureQuery, LastAverageTemperatureDto>
    {
        private readonly ICurrentWeatherRepository _currentWeatherRepository;
        public GetLastAverageTemperatureQueryHandler(ICurrentWeatherRepository currentWeatherRepository) 
        {
            _currentWeatherRepository = currentWeatherRepository;
        }
        public LastAverageTemperatureDto Execute(GetLastAverageTemperatureQuery query)
        {
            return _currentWeatherRepository.GetLastAverageTemperature();
        }
    }
}
