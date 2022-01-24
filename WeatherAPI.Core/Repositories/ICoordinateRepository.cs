using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Core.Repositories
{
    public interface ICoordinateRepository
    {
        public int SaveCoordinate(Coordinate coordinate);
    }
}
