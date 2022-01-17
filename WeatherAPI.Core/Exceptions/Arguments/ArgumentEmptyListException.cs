using System;

namespace WeatherAPI.Core.Exceptions.Arguments
{
    public class ArgumentEmptyListException : Exception
    {
        public ArgumentEmptyListException(string message) : base(message) { }
    }
}
