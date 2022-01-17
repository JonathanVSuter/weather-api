using System.Threading.Tasks;
using WeatherAPI.Core.Common.Requests;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface IRequestExecutor
    {
        Task<TResult> ExecuteRequest<T, TResult>(T request) where T : IRequest<Task<TResult>>;
    }
}
