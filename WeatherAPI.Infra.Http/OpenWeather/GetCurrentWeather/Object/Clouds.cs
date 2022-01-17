using Newtonsoft.Json;

namespace WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Object
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
