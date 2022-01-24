namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.DataBaseObject
{
    public class Coordinate
    {
        public int Id { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public Coordinate(double lon, double lat, int id)
        {
            Lon = lon;
            Lat = lat;
            Id = id;
        }
    }
}
