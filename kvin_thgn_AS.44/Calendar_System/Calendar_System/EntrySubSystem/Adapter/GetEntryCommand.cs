using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_System.EntrySubSystem.Adapter
{
    class GetEntryCommand
    {
        private GoogleAdapter _googleAdapter;

        public GetEntryCommand(GoogleAdapter googleAdapter)
        {
            _googleAdapter = googleAdapter;
        }
        public void Execute()
        {
            _googleAdapter.GetEntry();
        }
    }
}
