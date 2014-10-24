using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.StorageSubSystem
{
    class NoUserFoundException : Exception
    {
        public NoUserFoundException()
        {

        }
        public NoUserFoundException(string message)
            : base(message)
        {

        }

        public NoUserFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
