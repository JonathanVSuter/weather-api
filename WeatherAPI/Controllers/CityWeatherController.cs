using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WeatherAPI.Core.Common.InfraOperations;
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
        public string Get()
        {
            return "Teste";
        }
        public IActionResult GetWeatherFromCityByDate([FromBody] WeatherFromCityByDateViewModel weatherFromCityByDateViewModel)
        {
            var query = new GetWeatherFromCityByDateQuery(weatherFromCityByDateViewModel.City, weatherFromCityByDateViewModel.InitialDate, weatherFromCityByDateViewModel.FinalDate);

            var result = _queryExecutor.Execute<GetWeatherFromCityByDateQuery, IEnumerable<WeatherFromCityByDateDto>>(query);

            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }


    }
}
