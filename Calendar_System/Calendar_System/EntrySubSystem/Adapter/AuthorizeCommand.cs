using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.EntrySubSystem.Adapter
{
    class AuthorizeCommand
    {
        private GoogleAdapter _googleAdapter;

        public AuthorizeCommand(GoogleAdapter googleAdapter)
        {
            _googleAdapter = googleAdapter;
        }
        public void Execute(string user, string password)
        {
            _googleAdapter.Authorize(user, password);
        }
    }
}
