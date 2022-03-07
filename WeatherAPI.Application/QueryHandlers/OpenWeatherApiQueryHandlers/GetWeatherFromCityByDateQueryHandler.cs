using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.Pagination;
using WeatherAPI.Core.Common.QueryHandler;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.Repositories;

namespace WeatherAPI.Application.QueryHandlers.OpenWeatherApiQueryHandlers
{
    public class GetWeatherFromCityByDateQueryHandler : IQueryHandler<GetWeatherFromCityByDateQuery, IPaginatedQuery<WeatherFromCityByDateDto>>
    {
        private readonly ICurrentWeatherRepository _currentWeatherRepository;
        public GetWeatherFromCityByDateQueryHandler(ICurrentWeatherRepository currentWeatherRepository) 
        {
            _currentWeatherRepository = currentWeatherRepository;
        }
        public IPaginatedQuery<WeatherFromCityByDateDto> Execute(GetWeatherFromCityByDateQuery query)
        {
            return _currentWeatherRepository.GetWeatherFromCityByDate(query.CityName, query.InitialDate, query.FinalDate);
        }
    }
}
