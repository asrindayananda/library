using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class InvalidLoginException : UserDBException
    {
        private const string DEFAULT_MESSAGE = "Invalid login";

        public InvalidLoginException()
            : this(DEFAULT_MESSAGE)
        {
        }

        public InvalidLoginException(string message)
            : base(message)
        {
        }

        public InvalidLoginException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
