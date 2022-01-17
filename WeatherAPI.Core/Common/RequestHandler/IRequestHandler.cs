using System.Threading.Tasks;
using WeatherAPI.Core.Common.Requests;

namespace WeatherAPI.Core.Common.RequestHandler
{
    public interface IRequestHandler<T, TResult> where T : IRequest<Task<TResult>>
    {
        Task<TResult> Execute(T query);
    }
}
