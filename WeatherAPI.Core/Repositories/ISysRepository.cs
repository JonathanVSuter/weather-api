using WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business;

namespace WeatherAPI.Core.Repositories
{
    public interface ISysRepository
    {
        public int SaveSys(Sys sys);
    }
}
