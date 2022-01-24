using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAPI.Core.Exceptions.Arguments;
using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather
{
    public static class CurrentWeatherExtensions
    {
        public static CurrentLocalWeather AsBusiness(this CurrentLocalWeatherDto getCurrentWeatherObject)
        {
            if (getCurrentWeatherObject is null)
            {
                throw new ArgumentNullException(nameof(getCurrentWeatherObject));
            }

            return new CurrentLocalWeather(CoordToBusiness(getCurrentWeatherObject.Coord), WeatherToBusiness(getCurrentWeatherObject.Weather), MainToBusiness(getCurrentWeatherObject.Main),
                                                      getCurrentWeatherObject.Visibility, WindToBusiness(getCurrentWeatherObject.Wind), CloudsToBusiness(getCurrentWeatherObject.Clouds),
                                                      getCurrentWeatherObject.Dt, SysToBusiness(getCurrentWeatherObject.Sys), getCurrentWeatherObject.Timezone,
                                                      getCurrentWeatherObject.Id, getCurrentWeatherObject.Name, getCurrentWeatherObject.Cod);
        }
        public static Sys SysToBusiness(SysDto sys)
        {
            if (sys is null) throw new ArgumentNullException(nameof(sys));

            return new Sys(sys.Type, sys.Id, sys.Country, sys.Sunrise, sys.Sunset);
        }
        public static Main MainToBusiness(MainDto main)
        {
            if (main is null)
                throw new ArgumentNullException(nameof(main));

            return new Main(main.Temp, main.FeelsLike, main.TempMin, main.TempMax, main.Pressure, main.Humidity);
        }
        public static Coordinate CoordToBusiness(CoordinateDto coord)
        {
            if (coord is null)
                throw new ArgumentNullException(nameof(coord));

            return new Coordinate(coord.Lon, coord.Lat);
        }
        public static Cloud CloudsToBusiness(CloudsDto clouds)
        {
            if (clouds is null)
                throw new ArgumentNullException(nameof(clouds));

            return new Cloud(clouds.All);
        }
        public static Wind WindToBusiness(WindDto wind)
        {
            if (wind is null)
                throw new ArgumentNullException(nameof(wind));

            return new Wind(wind.Speed, wind.Deg, wind.Gust);

        }
        public static List<Weather> WeatherToBusiness(List<WeatherDto> weather)
        {
            if (weather is null)
                throw new ArgumentNullException(nameof(weather));
            if (!weather?.Any() ?? false)
                throw new ArgumentEmptyListException($"Argument {nameof(weather)} is a empty list");

            var weatherList = new List<Weather>();

            weather.ForEach(element =>
            {
                weatherList.Add(new Weather(element.Id, element.Main, element.Description, element.Icon));
            });

            return weatherList;
        }
    }
}
