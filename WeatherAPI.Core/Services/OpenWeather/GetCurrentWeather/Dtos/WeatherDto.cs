﻿namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Dtos
{
    public class WeatherDto
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
