using System;
using System.Collections.Generic;
using System.Text;

namespace API_Tester.Exceptions
{
    internal class InvalidUriInputException : Exception
    {
        public InvalidUriInputException()
        {
        }
        public InvalidUriInputException(string message)
            : base(message)
        {
        }
    }
}
