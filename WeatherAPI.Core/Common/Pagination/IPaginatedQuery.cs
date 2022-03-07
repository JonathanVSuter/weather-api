using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Common.Pagination
{
    public interface IPaginatedQuery<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Count { get; set; }
    }
}
