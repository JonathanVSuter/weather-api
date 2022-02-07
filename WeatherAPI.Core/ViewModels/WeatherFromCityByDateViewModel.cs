using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.ViewModels
{
    public class WeatherFromCityByDateViewModel
    {
        public string City { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
    }
}
