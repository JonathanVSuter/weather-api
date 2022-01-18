using System.Collections.Generic;

namespace WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos
{
    public class CurrentLocalWeatherDto
    {
        public CoordinateDto Coord { get; set; }
        public List<WeatherDto> Weather { get; set; }
        public string Base { get; set; }
        public MainDto Main { get; set; }
        public int Visibility { get; set; }
        public WindDto Wind { get; set; }
        public CloudsDto Clouds { get; set; }
        public int Dt { get; set; }
        public SysDto Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
