namespace WeatherAPI.Infra.Http.OpenWeather.GetCurrentWeather.Dtos
{
    public class SysDto
    {
        public int Type { get; set; }
        public int Id { get; set; }        
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
