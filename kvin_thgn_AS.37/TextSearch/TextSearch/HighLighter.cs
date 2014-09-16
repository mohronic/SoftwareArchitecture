using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextSearch
{
    public class HighLighter
    {
        private static string _command;
        /// <summary>
        /// Calls Print(string search, string path) method with args[0] and args[1].
        /// </summary>
        /// <param name="args">A string of arguments</param>
        public static void Main(string[] args)
        {
            Print(args[0], args[1]);
        }
        /// <summary>
        /// Reads a file from a filepath and find and highlights a given searchword, all URL's (words starting with http://) 
        /// and dates of the format Sat, 25 Aug 2012 18:36:26 -0400. Then writes file to console and marks found searchwords
        /// in yellow, URL's in blue and dates in red. The searchword can be modified using these signs:
        /// + means that two adjacent keywords should be present one after the other, e.g. text+file matches “text file” but does not match “text big file”
        /// * after a keyword means search for words starting with keyword e.g. inter* matches “internet”
        /// * before a keyword means search for words ending with keyword e.g. *net matches “internet” and “intranet”
        /// </summary>
        /// <param name="search">searchword</param>
        /// <param name="path">filepath</param>
        public static void Print(string search, string path)
        {
            string word = FindCommand(search);
            string textFile = TextFileReader.ReadFile(path);
            var withoutSpecial = new string(word.Where(c => Char.IsLetterOrDigit(c)
                                                || Char.IsWhiteSpace(c)).ToArray());
            if (word != withoutSpecial)
            {
                Console.WriteLine("Your string contains special regex characters. Please remove these and try again." +
                                  "The program only accepts letters and numbers");
            }
            else
            {
                var searchWords = SearchWords(word, path, _command);


                PrintAndHighlight(textFile, searchWords);
            }
        }
        private static string FindCommand(string word)
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
        /// <summary>
        /// Method searches for a the string "word" in another given string "fileName", all string starting with http:// (URL's)
        /// and all dates og the format Sat, 25 Aug 2012 18:36:26 -0400. Another string "Command"
        /// determines how the method will match words. If command == startsWith the search will find all string 
        /// starting with the given searchword. If command == endsWith the search will find all string 
        /// ending with the given searchword. The method returns a sorted List of Match sorted by their occurence in the string to be searched.
        /// </summary>
        /// <param name="word">The search word</param>
        /// <param name="fileName">The string to be searched in</param>
        /// <param name="command">Search modifier</param>
        /// <returns>List<list type="Match"></list></returns>
        private static List<Match> SearchWords(string word, string fileName, string command)
        {
            var words = new List<Match>();
            string text = TextFileReader.ReadFile(fileName);
            MatchCollection matches;
            if (command.Equals("startsWith"))
            {
                matches = Regex.Matches(text, @"(^| )" + word + @"\S*", RegexOptions.IgnoreCase);
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
            MatchCollection dates = Regex.Matches(text, @"\S*" + "[a-zA-z]{3}, [0-9]{2} [a-zA-z]{3} [0-9]{4} [0-2][0-9]:[0-5][0-9]:[0-5][0-9] -?[0-9]{4}" + @"\b", RegexOptions.IgnoreCase);
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
        /// <summary>
        /// Method accepts a string that will be printed. The List that is supplied 
        /// determines which word will be highlighted. The method highlights dates in red,
        /// URL's in blue and other searchwords in yellow. The rest of the words int the string
        /// will be printed without highlighting.
        /// </summary>
        /// <param name="textFile">The string that will be printed.</param>
        /// <param name="searchWord">The searchwords that will be highlighted</param>
        private static void PrintAndHighlight(string textFile, List<Match> searchWord)
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
                else if (searchWord.First().Value.StartsWith("http://"))
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
