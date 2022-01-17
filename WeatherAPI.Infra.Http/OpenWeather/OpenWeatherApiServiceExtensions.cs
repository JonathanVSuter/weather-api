using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAPI.Core.Exceptions.Arguments;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos;
using WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Object;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather
{
    public static class OpenWeatherApiServiceExtensions
    {
        public static CurrentLocalWeatherDto AsDto(this GetCurrentWeatherObject getCurrentWeatherObject) 
        {
            if (getCurrentWeatherObject is null)
            {
                throw new ArgumentNullException(nameof(getCurrentWeatherObject));
            }

            return new CurrentLocalWeatherDto()
            {
                Coord = CoordToDto(getCurrentWeatherObject.Coord),
                Clouds = CloudsToDto(getCurrentWeatherObject.Clouds),
                Weather = WeatherToDto(getCurrentWeatherObject.Weather),
                Wind = WindToDto(getCurrentWeatherObject.Wind),
                Main = MainToDto(getCurrentWeatherObject.Main),
                Sys = SysToDto(getCurrentWeatherObject.Sys),
                Base = getCurrentWeatherObject.Base,
                Cod = getCurrentWeatherObject.Cod,
                Dt = getCurrentWeatherObject.Dt,
                Id = getCurrentWeatherObject.Id,
                Name = getCurrentWeatherObject.Name,
                Timezone = getCurrentWeatherObject.Timezone,
                Visibility = getCurrentWeatherObject.Visibility                
            };            
        } 
        public static SysDto SysToDto(Sys sys)
        {
            if (sys is null) throw new ArgumentNullException(nameof(sys));

            return new SysDto()
            { 
                Country = sys.Country,
                Id = sys.Id,
                Sunrise = sys.Sunrise,
                Sunset = sys.Sunset,
                Type = sys.Type
            };
        }
        public static MainDto MainToDto(Main main)
        {
            if (main is null) 
                throw new ArgumentNullException(nameof(main));

            return new MainDto()
            {
                FeelsLike = main.FeelsLike,
                Humidity = main.Humidity,
                Pressure = main.Pressure,
                Temp = main.Temp,
                TempMax = main.TempMax,
                TempMin = main.TempMin
            };
        }
        public static CoordDto CoordToDto(Coord coord) 
        { 
            if(coord is null)
                throw new ArgumentNullException(nameof(coord));

            return new CoordDto()
            {
                Lat = coord.Lat,
                Lon = coord.Lon
            };
        }
        public static CloudsDto CloudsToDto(Clouds clouds) 
        {
            if (clouds is null)
                throw new ArgumentNullException(nameof(clouds));

            return new CloudsDto()
            {
                All = clouds.All
            };
        }
        public static WindDto WindToDto(Wind wind) 
        {
            if (wind is null)
                throw new ArgumentNullException(nameof(wind));

            return new WindDto()
            {
                Deg = wind.Deg,
                Speed = wind.Speed,
                Gust = wind.Gust                
            };
        }
        public static List<WeatherDto> WeatherToDto(List<Weather> weather) 
        {
            if (weather is null)
                throw new ArgumentNullException(nameof(weather));
            if (!weather?.Any() ?? false) 
                throw new ArgumentEmptyListException($"Argument {nameof(weather)} is a empty list");

            var weatherList = new List<WeatherDto>();

            weather.ForEach(element => 
            {
                weatherList.Add(new WeatherDto() 
                {
                    Description = element.Description,
                    Icon = element.Icon,
                    Id = element.Id,
                    Main = element.Main
                });
            });

            return weatherList;
        }
    }
}
