using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI.Core.Exceptions.Arguments
{
    public class ArgumentEmptyListException : Exception
    {
        public ArgumentEmptyListException(string message) : base(message) { }
    }
}
