using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Dtos
{
    public class LocalDto
    {
        public string Name { get; set; }
        public int Timezone { get; set; }
    }
}
