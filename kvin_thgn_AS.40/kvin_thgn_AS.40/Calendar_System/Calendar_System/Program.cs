using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Calendar_System.AccountSubSystem;
using Calendar_System.EntrySubSystem;
using Calendar_System.MainSystem;
using Calendar_System.StorageSubSystem;
using Calendar_System.Utility;

namespace Calendar_System
{
    class Program
    {
        // If you want to run as user in current implementation
        // Username is Hans (case sensitive!) and password is 12345.
        static void Main()
        {
            CalendarControl cControl = new CalendarControl();
        }
        /// <summary>
        /// Serialization test
        /// </summary>
        static void Main2()
        {
            var factory = new DatabaseFactory();
            var abstractStorage = factory.CreateStorage("test");
            var user = abstractStorage.GetUsers().First();
            List<Entry> entries = abstractStorage.GetEntriesForUser(user);
            
            //save the car list to a file
            SerializeEntries objectToSerialize = new SerializeEntries();
            objectToSerialize.Entries = entries;

            Serializer serializer = new Serializer();
            serializer.SerializeObject("tempEntries.txt", objectToSerialize);

            //the car list has been saved to outputFile.txt
            //read the file back from outputFile.txt

            objectToSerialize = serializer.DeSerializeObject("tempEntries.txt");
            List<Entry> entries2 = objectToSerialize.Entries;
            foreach (var entry in entries2)
            {
                Console.Out.WriteLine(entry.EntryName);
            }
        }
    }
}
