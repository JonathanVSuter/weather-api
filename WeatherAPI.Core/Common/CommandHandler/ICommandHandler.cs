using WeatherAPI.Core.Common.Command;

namespace WeatherAPI.Core.Common.CommandHandler
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
}
