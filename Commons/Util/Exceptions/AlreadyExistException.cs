using System;

namespace Util.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message) : base(message) { }
    }
}
