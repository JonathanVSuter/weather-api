using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.ViewModels
{
    public class WeatherFromCityByDateViewModel
    {
        public string City { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
