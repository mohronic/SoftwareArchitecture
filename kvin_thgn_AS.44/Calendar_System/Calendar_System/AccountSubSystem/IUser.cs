using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Calendar_System.EntrySubSystem;

namespace Calendar_System.AccountSubSystem
{
    public interface IUser
    {
        string GetFirstName();

        string GetLastName();

        string GetEmail();

        string GetPhone();

        bool GetAdmin();

        string GetPassword();

        List<Entry> GetEntryList();

        int? GetId();

        void GetObjectData(SerializationInfo info, StreamingContext context);

        int CompareTo(object obj);

        bool UpdateUser(string firstName, string lastName, string email, string phone, string password,
            bool admin, List<Entry> entryList);
    }
}
