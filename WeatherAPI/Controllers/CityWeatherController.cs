using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Common.Pagination;
using WeatherAPI.Core.Queries.OpenWeatherApi;
using WeatherAPI.Core.ViewModels;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityWeatherController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;

        public CityWeatherController(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }        
        [HttpGet]
        public IActionResult GetWeatherFromCityByDate([FromBody] WeatherFromCityByDateViewModel weatherFromCityByDateViewModel)
        {
            var query = new GetWeatherFromCityByDateQuery(weatherFromCityByDateViewModel.City, weatherFromCityByDateViewModel.InitialDate, weatherFromCityByDateViewModel.FinalDate);

            var result = _queryExecutor.Execute<GetWeatherFromCityByDateQuery, IPaginatedQuery<WeatherFromCityByDateDto>>(query);

            return Ok(new { result });
        }
        [HttpGet] 
        public IActionResult GetLastAverageTemperature() 
        {
            var query = new GetLastAverageTemperatureQuery();

            var lastAverageTemperature = _queryExecutor.Execute<GetLastAverageTemperatureQuery, LastAverageTemperatureDto>(query);

            return Ok(new { lastAverageTemperature });
        }
        [HttpGet]
        public IActionResult GetLastAverageTemperatureByCity(string city)
        {
            var query = new GetLastAverageTemperatureByCityQuery(city);

            var lastAverageTemperatureByCity = _queryExecutor.Execute<GetLastAverageTemperatureByCityQuery, LastAverageTemperatureCityDto>(query);

            return Ok(new { lastAverageTemperatureByCity });
        }
        /*--------------------------------- Ideias de consultas e operações para fazer com a base ---------------------------------*/
        //Temperatura média atual (do momento)-- GetLastAverageTemperature (ok);
        //Temperatura média atual por cidade-- GetLastAverageTemperatureByCity (ok);
        //Cidade com a temperatura mais quente (no momento e no geral);
        //Cidade com temperatura mais fria (no momento e no geral);
        //Temperatura média do dia, fazer isso por cidade e geral (ver se tem como separar por regiões));
        //Listar as cidades em que está ocorrendo chuva no momento (fazer isso para cada tipo de clima);        
        //Listar todas as cidades e mostrar individualmente os climas predominantes 
        //Listar todos os climas já registrados e em qual cidade ocorreu a última ocorrência do mesmo;
    }
}
