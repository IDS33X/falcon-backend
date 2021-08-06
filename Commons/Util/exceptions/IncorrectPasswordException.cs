using System;

namespace Util.exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public IncorrectPasswordException(){

        }

        public IncorrectPasswordException(string message): base(message){

        }
    }
}