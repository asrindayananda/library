using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class UserDBException : EasyLibraryException
    {
        public UserDBException()
            : base()
        {
        }

        public UserDBException(string message)
            : base(message)
        {
        }

        public UserDBException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
