using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class DeleteCurrentUserException : UserDBException
    {
        private const string DEFAULT_MESSAGE = "Cannot delete current user";

        public DeleteCurrentUserException()
            : this(DEFAULT_MESSAGE)
        {
        }

        public DeleteCurrentUserException(string message)
            : base(message)
        {
        }

        public DeleteCurrentUserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
