using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kt12
{

    class Program
    {
        static void Main()
        {
            string text = File.ReadAllText("text.txt");

            char[] separators = new char[] { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r', '\t' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string lowerWord = word.ToLower();

                if (wordFrequency.ContainsKey(lowerWord))
                {
                    wordFrequency[lowerWord]++;
                }
                else
                {
                    wordFrequency[lowerWord] = 1;
                }
            }

            var sortedWords = wordFrequency.OrderByDescending(pair => pair.Value);

            Console.WriteLine("words ");

            foreach (var pair in sortedWords)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}