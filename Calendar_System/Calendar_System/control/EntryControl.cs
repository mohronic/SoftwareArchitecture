using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System.control
{
    class EntryControl
    {
        public EntryControl()
        {
            
        }
        public void CreateEntry()
        {
            var entryForm = new EntryForm();
        }

        public void ModifyEntry(Entry entry)
        {
            var entryForm = new EntryForm(entry);
        }

        public void DeleteEntry(Entry entry)
        {
            
        }
    }
}
