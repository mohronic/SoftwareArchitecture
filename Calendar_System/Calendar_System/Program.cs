using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Calendar_System.control;
using Calendar_System.model;
using Calendar_System.view;

namespace Calendar_System
{
    class Program
    {
        // If you want to run as user in current implementation
        // Username is Hans (case sensitive!) and password is 12345.
        static void Main1()
        {
            CalendarControl cControl = new CalendarControl();
        }
        // If you want to run as admin in current implementation
        static void Main()
        {
            AdminControl ac = new AdminControl();
        }
        /// <summary>
        /// Serialization test
        /// </summary>
        static void Main2()
        {
            AbstractStorage a = new AbstractStorage(new FileStorage());
            var user = a.GetUsers().First();
            List<Entry> entries = a.GetEntriesForUser(user);
            
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
