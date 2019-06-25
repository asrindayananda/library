using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class CatalogueException : EasyLibraryException
    {
        public CatalogueException()
            : base()
        {
        }

        public CatalogueException(string message)
            : base(message)
        {
        }

        public CatalogueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
