using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.model;
using Calendar_System.model.Storage;
using Calendar_System.view;

namespace Calendar_System.control
{
    public class EntryControl
    {
        IStorage _abstractStorage;
        public EntryControl(String message, IStorage abstractStorage)
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
            var entryForm = new EntryForm(this);
            entryForm.ShowDialog();
        }
        // Creates a new EntryForm with an already existing Entry. Used when modifying an existing Entry.
        public void EntryFormModifyEntry(Entry entry)
        {
            var entryForm = new EntryForm(this, entry);
            entryForm.ShowDialog();
        }

        public void CreateAddPeopleForm()
        {
            //_addPeopleForm = new AddPeopleForm(_entryControl.GetAllUsersFromDb());
            throw new NotImplementedException();
        }

        public List<User> GetAllUsersFromDb()
        {
            return _abstractStorage.GetUsers();
        }

        public void DeleteEntryFromDb(Entry entry)
        {
            _abstractStorage.DeleteEntry(entry);
        }

        public void SendEntryToDb(DateTime startTime, DateTime endTime, string location, List<User> userList, string entryName)
        {
            var entry = new Entry(startTime, endTime, location, userList, entryName);
            _abstractStorage.CreateEntry(entry);
        }
    }
}
