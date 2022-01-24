using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.DataBaseObject
{
    public class Weather
    {
        public int Id { get; }
        public string Main { get; }
        public string Description { get; }
        public string Icon { get; }
        public Weather(int id, string main, string description, string icon)
        {
            Id = id;
            Main = main;
            Description = description;
            Icon = icon;
        }
    }
}
