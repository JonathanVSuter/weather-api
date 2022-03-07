using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.Pagination;

namespace WeatherAPI.Infra.Dapper.Pagination
{
    public class PaginatedQuery<T> : IPaginatedQuery<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Count { get; set; }
    }
}
