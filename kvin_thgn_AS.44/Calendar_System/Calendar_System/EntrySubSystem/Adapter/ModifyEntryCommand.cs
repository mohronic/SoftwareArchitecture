using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.EntrySubSystem.Adapter
{
    class ModifyEntryCommand
    {
        private GoogleAdapter _googleAdapter;

        public ModifyEntryCommand(GoogleAdapter googleAdapter)
        {
            _googleAdapter = googleAdapter;
        }
        public void Execute(Entry entry)
        {
            _googleAdapter.ModifyEntry(entry);
        }
    }
}
