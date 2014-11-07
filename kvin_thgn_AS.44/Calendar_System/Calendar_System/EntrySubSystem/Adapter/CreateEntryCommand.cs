using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.EntrySubSystem.Adapter
{
    class CreateEntryCommand
    {
        private GoogleAdapter _googleAdapter;

        public CreateEntryCommand(GoogleAdapter googleAdapter)
        {
            _googleAdapter = googleAdapter;
        }
        public void Execute(Entry entry)
        {
            _googleAdapter.CreateEntry(entry);
        }
    }
}
