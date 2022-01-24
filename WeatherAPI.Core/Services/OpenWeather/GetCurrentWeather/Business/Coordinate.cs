namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class Coordinate
    {        
        public double Lon { get; }
        public double Lat { get; }
        public Coordinate(double lon, double lat)
        {
            Lon = lon;
            Lat = lat;
        }
    }


}
