using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WeatherAPI.Infra.Dapper.Connections
{
    public class SqlServerDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters _dynamicParameters = new DynamicParameters();
        private readonly List<SqlParameter> _sqlServerParameters = new List<SqlParameter>();

        public void Add(string name, SqlDbType sqlServerDbType, ParameterDirection parameterDirection, object value = null, int size = 0)
        {
            SqlParameter sqlParameter;
            if(size > 0) 
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = name;
                sqlParameter.SqlDbType = sqlServerDbType;
                sqlParameter.Direction = parameterDirection;
                sqlParameter.Value = value;
                sqlParameter.Size = size;
            }
            else 
            {
                sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = name;
                sqlParameter.SqlDbType = sqlServerDbType;
                sqlParameter.Direction = parameterDirection;
                sqlParameter.Value = value;                
            }
            _sqlServerParameters.Add(sqlParameter);
        }

        public void Add(string name, SqlDbType sqlServerDbType, ParameterDirection parameterDirection) 
        {
            var sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = name;
            sqlParameter.SqlDbType = sqlServerDbType;
            sqlParameter.Direction = parameterDirection;
            _sqlServerParameters.Add(sqlParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)_dynamicParameters).AddParameters(command, identity);

            var sqlCommand = command as SqlCommand;

            if(sqlCommand != null) 
            {
                sqlCommand.Parameters.AddRange(_sqlServerParameters.ToArray());
            }
        }
        
        public T Get<T>(string name) 
        {
            return (T)_sqlServerParameters.FirstOrDefault(e => e.ParameterName.Equals(name)).Value;
        }
    }
}
