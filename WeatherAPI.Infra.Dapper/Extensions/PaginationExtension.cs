using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WeatherAPI.Core.Common.Pagination;
using WeatherAPI.Infra.Dapper.Pagination;

namespace WeatherAPI.Infra.Dapper.Extensions
{
    public static class PaginationExtension
    {
        public static IPaginatedQuery<T> Query<T>(this IDbConnection cnn, string sql, object parameters, IPaginationInfo paginationInfo, int? timeout = 0) 
        {
            var query = new PaginatedQuery<T>();
            var paginatedSql = string.Empty;
            var sqlCount = string.Empty;

            if(cnn is SqlConnection)
            {
                sqlCount = $"SELECT COUNT(1) FROM ({sql}) t_pagination";

                paginatedSql = $@"SELECT * FROM 
                                    (SELECT ROW_NUMBER() over 
                                        (order by queryResult.{paginationInfo.OrderBy}) as ""RowNumber"", * FROM ({sql}) queryResult) paginatedQuery 
                                     WHERE paginatedQuery.""RowNumber"" 
                                        BETWEEN {(paginationInfo.PageNumber - 1) * paginationInfo.PageSize + 1} 
                                        AND {paginationInfo.PageNumber * paginationInfo.PageSize} ";
            }
            query.Count = cnn.ExecuteScalar<int>(sqlCount, parameters, commandTimeout: timeout);
            query.Result = cnn.Query<T>(paginatedSql, parameters, commandTimeout: timeout);

            return query;
        }
    }
}
