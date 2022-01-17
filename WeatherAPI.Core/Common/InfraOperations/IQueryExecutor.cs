using WeatherAPI.Core.Common.Queries;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IQueryExecutor
    {
        TResult Execute<T, TResult>(T query) where T : IQuery<TResult>;
    }
}
