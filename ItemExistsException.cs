using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_2.Exceptions
{
    public class ItemExistsException : CatalogueException
    {
        private const string DEFAULT_MESSAGE = "Item already exists";

        public ItemExistsException()
            : this(DEFAULT_MESSAGE)
        {
        }

        public ItemExistsException(string message)
            : base(message)
        {
        }

        public ItemExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
