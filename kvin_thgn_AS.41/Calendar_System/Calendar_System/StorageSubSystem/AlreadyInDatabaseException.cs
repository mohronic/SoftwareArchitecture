using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.StorageSubSystem
{
    public class AlreadyInDatabaseException : Exception
    {
        public AlreadyInDatabaseException()
        {

        }
        public AlreadyInDatabaseException(string message)
            : base(message)
        {

        }

        public AlreadyInDatabaseException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
