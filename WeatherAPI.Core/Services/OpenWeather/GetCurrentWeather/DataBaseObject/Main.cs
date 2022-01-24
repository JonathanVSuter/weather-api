using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.DataBaseObject
{
    public class Main
    {
        public int Id { get; set; }
        public double Temp { get; }
        public double FeelsLike { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public int Pressure { get; }
        public int Humidity { get; }
        public Main(double temp, double feelsLike, double tempMin, double tempMax, int pressure, int humidity, int id)
        {
            Temp = temp;
            FeelsLike = feelsLike;
            TempMin = tempMin;
            TempMax = tempMax;
            Pressure = pressure;
            Humidity = humidity;
            Id = id;
        }
    }
}
