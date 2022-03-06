using System.Collections.Generic;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class CurrentLocalWeather
    {
        public Coordinate Coord { get; }
        public IReadOnlyList<Weather> Weather { get; }
        public string Base { get; }
        public AtmosphereConditions AtmosphereConditions { get; }
        public int Visibility { get; }
        public Wind Wind { get; }
        public Cloud Clouds { get; }
        public int Dt { get; }
        public Sys Sys { get; }
        public int Id { get; }
        public Local Local { get; }
        public CurrentLocalWeather(Coordinate coord, List<Weather> weather, AtmosphereConditions main, int visibility, Wind wind, Cloud clouds, int dt, Sys sys, int id, Local local)
        {
            this.Coord = coord;
            this.Weather = weather;
            this.AtmosphereConditions = main;
            this.Visibility = visibility;
            this.Wind = wind;
            this.Clouds = clouds;
            this.Dt = dt;
            this.Sys = sys;
            this.Id = id;
            this.Local = local;
        }
    }
}
