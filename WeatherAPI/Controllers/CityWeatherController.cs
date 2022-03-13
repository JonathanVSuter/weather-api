using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet]
        public IActionResult GetCityWithHottestTemperature() 
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetCityWithColdestTemperature() 
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetAverageTemperatureByCityAndDay(string city, string date) 
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetAverageTemperatureOfAll(string city, string date)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetAverageTemperatureByCity(string city)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetAllCitiesWhereIsRaning() 
        {
            throw new NotImplementedException();
        }        
        [HttpGet]
        public IActionResult GetAllCitiesAndShowTheirDominantWeather()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public IActionResult GetAllWeathersAndTheirLastOccurrence()
        {
            throw new NotImplementedException();
        }
        /*--------------------------------- Ideias de consultas e operações para fazer com a base ---------------------------------*/
        //Temperatura média atual (do momento)-- GetLastAverageTemperature (ok);
        //Temperatura média atual por cidade-- GetLastAverageTemperatureByCity (ok);
        //Cidade com a temperatura mais quente (no momento e no geral) GetCityWithHottestTemperature;
        //Cidade com temperatura mais fria (no momento e no geral) GetCityWithColdestTemperature;
        //Temperatura média do dia, fazer isso por cidade e geral (ver se tem como separar por regiões)) GetAverageTemperatureOfAll;
        //Listar as cidades em que está ocorrendo chuva no momento (fazer isso para cada tipo de clima) GetAllCitiesWhereIsRaning ;        
        //Listar todas as cidades e mostrar individualmente os climas predominantes 
        //Listar todos os climas já registrados e em qual cidade ocorreu a última ocorrência do mesmo;
    }
}
