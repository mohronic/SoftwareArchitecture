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
        readonly AbstractStorage _abstractStorage = new StorageImp();
        public EntryControl()
        {
        }
        // Creates a new EntryForm from scratch.
        public void EntryFormCreateEntry()
        {
            var entryForm = new EntryForm(this);
            entryForm.ShowDialog();
        }
        // Creates a new EntryForm with an already existing Entry. Used when modifying an existing Entry.
        public void EntryFormModifyEntry(Entry entry)
        {
            var entryForm = new EntryForm(this, entry);
            entryForm.ShowDialog();
        }

        public List<User> GetAllUsersFromDb()
        {
            return _abstractStorage.GetUsers();
        }

        public void DeleteEntryFromDb(Entry entry)
        {
            _abstractStorage.DeleteEntry(entry);
        }

        public void SendEntryToDb(Entry entry)
        {
            _abstractStorage.CreateEntry(entry);
        }
    }
}
