using WeatherAPI.Core.Common.Command;

namespace WeatherAPI.Core.Common.InfraOperations
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
        TResult Dispatch<T, TResult>(T command) where T : ICommand;
    }
}
