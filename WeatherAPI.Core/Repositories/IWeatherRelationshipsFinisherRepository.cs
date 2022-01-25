using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Repositories
{
    public interface IWeatherRelationshipsFinisherRepository
    {
        void AttachLocalWeather(int idLocal, IList<int> idWeathers);
        void AttachLocalWind(int idLocal, int idWind);
        void AttachLocalCloud(int idLocal, int idCloud);
    }
}
