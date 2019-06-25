using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class InvalidPasswordFileEntryException : UserDBException
    {
        private const string DEFAULT_MESSAGE = "Invalid password file entry";

        public InvalidPasswordFileEntryException()
            : this(DEFAULT_MESSAGE)
        {
        }

        public InvalidPasswordFileEntryException(string message)
            : base(message)
        {
        }

        public InvalidPasswordFileEntryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
