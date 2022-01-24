using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Repositories
{
    public interface IWeatherRelationshipsFinisherRepository
    {
        void SaveLocalWeather(int idLocal, IList<int> idWeathers);
        void SaveLocalWind(int idLocal, int idWind);
        void SaveLocalCloud(int idLocal, int idCloud);
    }
}
