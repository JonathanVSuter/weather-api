using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.QueryHandler;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.QueryHandlers.OpenWeatherApiQueryHandlers
{
    public class GetLastAverageTemperatureByCityQueryHandler : IQueryHandler<GetLastAverageTemperatureByCityQuery, LastAverageTemperatureCityDto>
    {
        private readonly ICurrentWeatherRepository _currentWeatherRepository;
        public GetLastAverageTemperatureByCityQueryHandler(ICurrentWeatherRepository currentWeatherRepository) 
        {
            _currentWeatherRepository = currentWeatherRepository;
        }

        public LastAverageTemperatureCityDto Execute(GetLastAverageTemperatureByCityQuery query)
        {
            return _currentWeatherRepository.GetLastAverageTemperatureByCity(query.City);
        }
    }
}
