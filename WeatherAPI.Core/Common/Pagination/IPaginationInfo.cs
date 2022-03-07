using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Common.Pagination
{
    public interface IPaginationInfo
    {
        public static IPaginationInfo Default { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }
    }
}
