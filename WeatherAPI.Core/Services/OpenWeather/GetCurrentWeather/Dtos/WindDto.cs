﻿namespace WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos
{
    public class WindDto
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }
}
