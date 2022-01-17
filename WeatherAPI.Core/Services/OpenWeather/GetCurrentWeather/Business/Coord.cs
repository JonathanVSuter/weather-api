namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class Coord
    {
        public double Lon { get; }
        public double Lat { get; }
        public Coord(double lon, double lat)
        {
            this.Lon = lon;
            this.Lat = lat;
        }
    }


}
