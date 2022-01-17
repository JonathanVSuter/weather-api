using Autofac;
using System;
using WeatherAPI.Core.Common.Command;
using WeatherAPI.Core.Common.CommandHandler;
using WeatherAPI.Core.Common.InfraOperations;

namespace WeatherAPI.Application.BaseOperations
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var handler = _context.Resolve<ICommandHandler<T>>();
            handler.Handle(command);
        }

        public TResult Dispatch<T, TResult>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var handler = _context.Resolve<ICommandHandlerWithResult<T, TResult>>();
            return handler.Handle(command);
        }
    }
}
