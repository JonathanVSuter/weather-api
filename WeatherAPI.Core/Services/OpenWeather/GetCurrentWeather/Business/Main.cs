namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class Main
    {
        public double Temp { get; }
        public double FeelsLike { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public int Pressure { get; }
        public int Humidity { get; }
        public Main(double temp, double feelsLike, double tempMin, double tempMax, int pressure, int humidity)
        {
            Temp = temp;
            FeelsLike = feelsLike;
            TempMin = tempMin;
            TempMax = tempMax;
            Pressure = pressure;
            Humidity = humidity;
        }
    }


}
