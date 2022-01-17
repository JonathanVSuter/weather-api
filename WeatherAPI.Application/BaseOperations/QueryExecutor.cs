using Autofac;
using System;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Common.Queries;
using WeatherAPI.Core.Common.QueryHandler;

namespace WeatherAPI.Application.BaseOperations
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IComponentContext _context;
        public QueryExecutor(IComponentContext context)
        {
            _context = context;
        }
        public TResult Execute<T, TResult>(T query) where T : IQuery<TResult>
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var executor = _context.Resolve<IQueryHandler<T, TResult>>();

            return executor.Execute(query);
        }
    }
}
