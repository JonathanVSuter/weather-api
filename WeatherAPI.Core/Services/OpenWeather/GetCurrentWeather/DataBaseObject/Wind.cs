namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.DataBaseObject
{
    public class Wind
    {
        public int Id { get; set; }
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }

        public Wind(double speed, int deg, double gust, int id)
        {
            Speed = speed;
            Deg = deg;
            Gust = gust;
            Id = id;
        }
    }
}
