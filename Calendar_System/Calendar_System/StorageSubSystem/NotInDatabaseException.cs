using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.StorageSubSystem
{
    public class NotInDatabaseException : Exception
    {
        public NotInDatabaseException()
        {

        }
        public NotInDatabaseException(string message)
            : base(message)
        {

        }

        public NotInDatabaseException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
