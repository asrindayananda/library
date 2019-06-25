using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class UserNotFoundException : UserDBException
    {
        private const string DEFAULT_MESSAGE = "User not found";

        public UserNotFoundException()
            : this(DEFAULT_MESSAGE)
        {
        }

        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
