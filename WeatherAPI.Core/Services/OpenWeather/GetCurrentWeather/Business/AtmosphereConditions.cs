namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class AtmosphereConditions
    {
        public double Temp { get; }
        public double FeelsLike { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public int Pressure { get; }
        public int Humidity { get; }
        public AtmosphereConditions(double temp, double feelsLike, double tempMin, double tempMax, int pressure, int humidity)
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
