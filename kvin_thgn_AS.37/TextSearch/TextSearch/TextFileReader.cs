using System;
using System.IO;

namespace BDSA14
{
    /// <summary>
    ///   Utility class for reading text files into a single string.
    /// </summary>
    static class TextFileReader
    {
        public static string ReadFile(string filename)
        {
            try
            {
                using (var reader = new StreamReader(filename))
                {   
                    //This reads the entire file
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //Might happen if the file is not text or non-existent
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}