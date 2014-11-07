using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.EntrySubSystem
{
    public class UpdateFailedException : Exception
    {
        public UpdateFailedException()
        {

        }
        public UpdateFailedException(string message)
            : base(message)
        {

        }

        public UpdateFailedException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
