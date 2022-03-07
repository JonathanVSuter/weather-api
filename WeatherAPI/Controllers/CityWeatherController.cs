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

        //Temperatura média atual (do momento);
        //Temperatura média atual por cidade;
        //Cidade com a temperatura mais quente (no momento e no geral);
        //Cidade com temperatura mais fria (no momento e no geral);
        //Temperatura média do dia, fazer isso por cidade e geral (ver se tem como separar por regiões));
        //Listar as cidades em que está ocorrendo chuva no momento (fazer isso para cada tipo de clima);        
        //Listar todas as cidades e mostrar individualmente os climas predominantes 
        //Listar todos os climas já registrados e em qual cidade ocorreu a última ocorrência do mesmo;
    }
}
