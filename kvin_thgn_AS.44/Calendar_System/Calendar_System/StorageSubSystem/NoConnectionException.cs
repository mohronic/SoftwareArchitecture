using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.StorageSubSystem
{
    public class NoConnectionException : Exception
    {
        public NoConnectionException()
        {

        }
        public NoConnectionException(string message)
            : base(message)
        {

        }

        public NoConnectionException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
