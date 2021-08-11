using System;

namespace Util.Exceptions
{
    public class DoesNotExistException : Exception
    {
        public DoesNotExistException(string message) : base(message) {}
    }
}