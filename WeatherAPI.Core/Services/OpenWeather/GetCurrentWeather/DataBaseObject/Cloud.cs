using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.DataBaseObject
{
    public class Cloud
    {
        public int Id { get; set; }
        public int All { get; set; }
        public Cloud(int all, int id)
        {
            All = all;
            Id = id;
        }
    }

}
