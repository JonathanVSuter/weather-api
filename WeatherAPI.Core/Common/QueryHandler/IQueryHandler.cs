using WeatherAPI.Core.Common.Queries;

namespace WeatherAPI.Core.Common.QueryHandler
{
    public interface IQueryHandler<in T, out TResult> where T : IQuery<TResult>
    {
        TResult Execute(T query);
    }
}
