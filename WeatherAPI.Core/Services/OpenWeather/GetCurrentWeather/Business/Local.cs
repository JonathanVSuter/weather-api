using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class Local
    {
        public string Name { get; set; }
        public int Timezone { get; set; }
        
        public Local(string name, int timezone)
        {
            Name = name;
            Timezone = timezone;
        }
    }
}
