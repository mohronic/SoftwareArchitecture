using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.StorageSubSystem
{
    class EntryNotFoundException : Exception
    {
        public EntryNotFoundException()
        {

        }
        public EntryNotFoundException(string message)
            : base(message)
        {

        }

        public EntryNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
