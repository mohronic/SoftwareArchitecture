using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.EntrySubSystem.Adapter
{
    class SendEntriesCommand
    {
        private GoogleAdapter _googleAdapter;

        public SendEntriesCommand(GoogleAdapter googleAdapter)
        {
            _googleAdapter = googleAdapter;
        }
        public void Execute(List<Entry> entries)
        {
            _googleAdapter.SendEntries(entries);
        }
    }
}
