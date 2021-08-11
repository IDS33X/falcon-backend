using System;

namespace Util.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public IncorrectPasswordException(string message) : base(message) {}
    }
}