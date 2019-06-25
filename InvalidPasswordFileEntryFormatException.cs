using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class InvalidPasswordFileEntryFormatException : UserDBException
    {
        private const string DEFAULT_MESSAGE = "Invalid user found in passwords file";

        public InvalidPasswordFileEntryFormatException()
            : this(DEFAULT_MESSAGE)
        {
        }

        public InvalidPasswordFileEntryFormatException(string message)
            : base(message)
        {
        }

        public InvalidPasswordFileEntryFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
