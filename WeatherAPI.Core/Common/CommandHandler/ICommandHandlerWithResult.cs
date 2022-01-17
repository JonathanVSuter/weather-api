namespace WeatherAPI.Core.Common.CommandHandler
{
    public interface ICommandHandlerWithResult<in T, out TResult>
    {
        TResult Handle(T command);
    }
}
