using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.ViewModels
{
    public interface BaseViewModel
    {
        int Page { get; set; }
        int RegistersPerPage { get; set; }
        string InitialDate { get; set; }
        string FinalDate { get; set; }
    }
}
