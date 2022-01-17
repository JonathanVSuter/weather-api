using Newtonsoft.Json;

namespace WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Object
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}
