using System.Collections.Generic;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class CurrentLocalWeather
    {
        public Coord Coord { get; }
        public IReadOnlyList<Weather> Weather { get; }
        public string Base { get; }
        public Main Main { get; }
        public int Visibility { get; }
        public Wind Wind { get; }
        public Clouds Clouds { get; }
        public int Dt { get; }
        public Sys Sys { get; }
        public int Timezone { get; }
        public int Id { get; }
        public string Name { get; }
        public int Cod { get; }
        public CurrentLocalWeather(Coord coord, List<Weather> weather, Main main, int visibility, Wind wind, Clouds clouds, int dt, Sys sys, int timezone, int id, string name, int cod)
        {
            this.Coord = coord;
            this.Weather = weather;
            this.Main = main;
            this.Visibility = visibility;
            this.Wind = wind;
            this.Clouds = clouds;
            this.Dt = dt;
            this.Sys = sys;
            this.Timezone = timezone;
            this.Id = id;
            this.Name = name;
            this.Cod = cod;
        }
    }
}
