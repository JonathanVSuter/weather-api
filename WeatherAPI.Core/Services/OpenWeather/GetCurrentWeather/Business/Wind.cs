﻿namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class Wind
    {
        public double Speed { get; }
        public int Deg { get; }
        public double Gust { get; }

        public Wind(double speed, int deg, double gust)
        {
            Speed = speed;
            Deg = deg;
            Gust = gust;
        }
    }


}
