using Autofac;
using System;
using System.Threading.Tasks;
using WeatherAPI.Core.Common.InfraOperations;
using WeatherAPI.Core.Common.RequestHandler;
using WeatherAPI.Core.Common.Requests;

namespace WeatherAPI.Application.BaseOperations
{
    public class RequestExecutor : IRequestExecutor
    {
        private readonly IComponentContext _context;
        public RequestExecutor(IComponentContext context)
        {
            _context = context;
        }
        public Task<TResult> ExecuteRequest<T, TResult>(T request) where T : IRequest<Task<TResult>>
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var executor = _context.Resolve<IRequestHandler<T, TResult>>();

            return executor.Execute(request);
        }
    }
}
