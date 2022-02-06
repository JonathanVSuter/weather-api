using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.QueryHandler;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.QueryHandlers.OpenWeatherApiQueryHandlers
{
    public class GetWeatherFromCityByDateQueryHandler : IQueryHandler<GetWeatherFromCityByDateQuery, IEnumerable<WeatherFromCityByDateDto>>
    {
        private readonly ICurrentWeatherRepository _currentWeatherRepository;
        public GetWeatherFromCityByDateQueryHandler(ICurrentWeatherRepository currentWeatherRepository) 
        {
            _currentWeatherRepository = currentWeatherRepository;
        }
        public IEnumerable<WeatherFromCityByDateDto> Execute(GetWeatherFromCityByDateQuery query)
        {
            return _currentWeatherRepository.GetWeatherFromCityByDate(query.CityName, query.StartDate, query.FinalDate);
        }
    }
}
