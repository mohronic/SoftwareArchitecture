using System;
using System.Collections.Generic;
using System.Linq;
using Calendar_System.AccountSubSystem;
using Calendar_System.StorageSubSystem;

namespace Calendar_System.EntrySubSystem
{
    public class EntryControl
    {
        private IAbstractStorage _abstractStorage;
        public EntryControl(String message, IAbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            if (message.Equals("newEntry"))
            {
                EntryFormCreateEntry();
            }
            if (message.Equals("modifyEntry"))
            {
                // Just to simulate editing. Searching will be enabled.
                var user = _abstractStorage.GetUsers().First();
                var entry = _abstractStorage.GetEntriesForUser(user).First();
                EntryFormModifyEntry(entry);   
            }
        }
        // Creates a new EntryForm from scratch.
        public void EntryFormCreateEntry()
        {
            var entryForm = new EntryForm(this, new Entry());
            entryForm.Show();
        }
        // Creates a new EntryForm with an already existing Entry. Used when modifying an existing Entry.
        public void EntryFormModifyEntry(Entry entry)
        {
            var entryForm = new EntryForm(this, entry);
            entryForm.Show();
        }

        public void CreateAddPeopleForm()
        {
            //_addPeopleForm = new AddPeopleForm(_entryControl.GetAllUsersFromDb());
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsersFromDb()
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
