using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.Exceptions
{
    class UserDBIOException : UserDBIOException
    {
        public UserDBIOException()
            : base()
        {
        }

        public UserDBIOException(string message)
            : base(message)
        {
        }

        public UserDBIOException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        //catch exeception from read/rite of user database file

        
        public Object UserDBIOException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
        
        //Throw previous object

    
    }
}
