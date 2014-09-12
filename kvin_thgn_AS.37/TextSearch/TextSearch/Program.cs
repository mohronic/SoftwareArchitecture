using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using BDSA14;
using System.Text.RegularExpressions;

namespace TextSearch
{
    internal class Program
    {
        private static string _command;
        //        + means that two adjacent keywords should be present one after the other, e.g. text + file matches “text file” but does not match “text big file”
        //* after a keyword means search for words starting with keyword e.g. inter* matches “internet”
        //* before a keyword means search for words ending with keyword e.g. *net matches “internet” and “intranet”
        public static void Main(string[] args)
        {
            string word = FindCommand(args[0]);
            Directory.SetCurrentDirectory(
                @"C:\Users\Trondur\Documents\Visual Studio 2013\Projects\TextSearch\TextSearch");
            var indexes = SearchWord(word, "TestFile.txt", _command);
            var words = SearchWords(word, "TestFile.txt", _command);
            string textFile = TextFileReader.ReadFile("TestFile.txt");

            PrintAndHighlight(indexes, textFile, words);
        }

        public static string FindCommand(string word)
        {
            if (word.StartsWith("*"))
            {
                _command = "endsWith";
                return word.Substring(1);
            }
            if (word.EndsWith("*"))
            {
                _command = "startsWith";
                return word.Substring(0, word.Length - 1);
            }
            if (word.Contains("+"))
            {
                _command = "";
                var twoWord = word.Split('+');
                return twoWord[0] + " " + twoWord[1];
            }
            _command = "";
            return word;
        }

        public static List<int> SearchWord(string word, string fileName, string command)
        {
            var indexes = new List<int>();
            var words = new List<string>();
            string text = TextFileReader.ReadFile(fileName);
            MatchCollection matches;
            if (command.Equals("startsWith"))
            {
                matches = Regex.Matches(text, @"\b" + word + @"\S*", RegexOptions.IgnoreCase);
            }
            else if (command.Equals("endsWith"))
            {
                matches = Regex.Matches(text, @"\S*" + word + @"\b", RegexOptions.IgnoreCase);
            }
            else
            {
                matches = Regex.Matches(text, @"\b" + word + @"\b", RegexOptions.IgnoreCase);
            }

            foreach (Match match in matches)
            {
                indexes.Add(match.Index);
                words.Add(match.Value);
            }
            return indexes;
        }
        public static List<string> SearchWords(string word, string fileName, string command)
        {
            var indexes = new List<int>();
            var words = new List<string>();
            string text = TextFileReader.ReadFile(fileName);
            MatchCollection matches;
            if (command.Equals("startsWith"))
            {
                matches = Regex.Matches(text, @"\b" + word + @"\S*", RegexOptions.IgnoreCase);
            }
            else if (command.Equals("endsWith"))
            {
                matches = Regex.Matches(text, @"\S*" + word + @"\b", RegexOptions.IgnoreCase);
            }
            else
            {
                matches = Regex.Matches(text, @"\b" + word + @"\b", RegexOptions.IgnoreCase);
            }

            foreach (Match match in matches)
            {
                indexes.Add(match.Index);
                words.Add(match.Value);
            }
            return words;
        }

        public static void PrintAndHighlight(List<int> indexes, string textFile, List<string> searchWord)
        {
            int start = 0;
            for (int i = 0; i < indexes.Count; i++)
            {
                Console.Write(textFile.Substring(start, indexes[i] - start));
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(searchWord[i]);
                Console.ResetColor();
                start = indexes[i] + searchWord[i].Length;
            }
            Console.WriteLine(textFile.Substring(start));
        }
    }
}
