using Newtonsoft.Json;

namespace WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Object
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
}
