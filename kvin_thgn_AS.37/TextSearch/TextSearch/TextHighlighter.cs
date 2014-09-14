using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BDSA14;

namespace TextSearch
{  
    class TextHighlighter
    {
        private static string _command;
        public static void Main(string[] args)
        {
            string word = FindCommand(args[0]);
            Directory.SetCurrentDirectory(
                @"C:\Users\Trondur\Documents\Visual Studio 2013\Projects\TextSearch\TextSearch");
            var matchingWords = SearchWords(word, "TestFile.txt", _command);
            string textFile = TextFileReader.ReadFile("TestFile.txt");
            string[] stringArr = StringToArray(matchingWords, textFile);
            for (int i = 0; i < stringArr.Length; i++)
            {
                Console.Write(stringArr[i]);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                if (matchingWords.Count > 0)
                {
                    if (matchingWords.First().StartsWith("http"))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (matchingWords.First().StartsWith("Sun") || matchingWords.First().StartsWith("Sat"))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(matchingWords.First());
                    matchingWords.RemoveAt(0);
                }
                Console.ResetColor();
            }
        }
        public static List<String> SearchWords(string word, string fileName, string command)
        {
            var words = new List<Match>();
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
            List<string> list = new List<string>();
            foreach (var g in words)
            {
                list.Add(g.Value);
            }
            return list;
        }

        public static string[] StringToArray(List<string> searchWords, string textFile)
        {
            var stringWithoutSearchWords = searchWords.ToArray();
            return textFile.Split(stringWithoutSearchWords, StringSplitOptions.None);
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
    }
    
}
