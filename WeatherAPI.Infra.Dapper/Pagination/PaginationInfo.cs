using System;
using System.Collections.Generic;
using System.Text;
using WeatherAPI.Core.Common.Pagination;

namespace WeatherAPI.Infra.Dapper.Pagination
{
    public class PaginationInfo : IPaginationInfo
    {
        public static PaginationInfo Default { get; set; } = new PaginationInfo();
        public int PageSize { get; set; } = 36;
        public int PageNumber { get; set; } = 1;
        public string OrderBy { get; set; } = "CreatedDate";

        public PaginationInfo(){}
        public PaginationInfo(int pageSize, int pageNumber, string orderBy)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            OrderBy = orderBy;
        }
    }
}
