using System;

namespace Util.exceptions
{
    public class DoesNotExistException : Exception
    {
        public DoesNotExistException(){

        }

        public DoesNotExistException(string message): base(message){

        }

    }
}