using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BDSA14;

namespace TextSearch
{
    class TextHighLighter2
    {
        private static string _command;
        //+ means that two adjacent keywords should be present one after the other, e.g. text + file matches “text file” but does not match “text big file”
        //* after a keyword means search for words starting with keyword e.g. inter* matches “internet”
        //* before a keyword means search for words ending with keyword e.g. *net matches “internet” and “intranet”
        public static void Main(string[] args)
        {
            string word = FindCommand(args[0]);
            Directory.SetCurrentDirectory(
                @"C:\Users\Trondur\Documents\Visual Studio 2013\Projects\TextSearch\TextSearch");
            var searchWords = SearchWords(word, "TestFile.txt", _command);
            string textFile = TextFileReader.ReadFile("TestFile.txt");

            PrintAndHighlight(textFile, searchWords);
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

        public static List<Match> SearchWords(string word, string fileName, string command)
        {
            var words = new List<Match>();
            string text = TextFileReader.ReadFile(fileName);
            MatchCollection matches;
            if (command.Equals("startsWith"))
            {
                matches = Regex.Matches(text, @"\ " + word + @"\S*", RegexOptions.IgnoreCase);
            }
            else if (command.Equals("endsWith"))
            {
                matches = Regex.Matches(text, @"\S*" + word + @"\b", RegexOptions.IgnoreCase);
            }
            else
            {
                matches = Regex.Matches(text, @"\b" + word + @"\b", RegexOptions.IgnoreCase);
            }
            MatchCollection urls = Regex.Matches(text, @"\S*" + "http://" + @"\S*", RegexOptions.IgnoreCase);
            MatchCollection dates = Regex.Matches(text, @"\S*" + "[a-zA-z]{3}, [0-9]{2} [a-zA-z]{3} [0-9]{4} [0-2][0-9]:[0-5][0-9]:[0-5][0-9] -0400" + @"\b", RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                words.Add(match);
            }
            foreach (Match match in urls)
            {
                words.Add(match);
            }
            foreach (Match match in dates)
            {
                words.Add(match);
            }
            words = words.OrderBy(o => o.Index).ToList();
            return words;
        }

        public static void PrintAndHighlight(string textFile, List<Match> searchWord)
        {
            int start = 0;
            int howOften = searchWord.Count;
            for (int i = 0; i < howOften; i++)
            {
                Console.Write(textFile.Substring(start, searchWord.First().Index - start));
                Console.ForegroundColor = ConsoleColor.Black;
                if (searchWord.First().Value.StartsWith("Sat") || searchWord.First().Value.StartsWith("Sun"))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (searchWord.First().Value.StartsWith("http"))
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                Console.Write(searchWord.First());
                Console.ResetColor();
                start = searchWord.First().Index + searchWord.First().Value.Length;
                searchWord.RemoveAt(0);
            }
            Console.WriteLine(textFile.Substring(start));
        }
    }
}
