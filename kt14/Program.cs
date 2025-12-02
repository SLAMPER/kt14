/*

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

*/

/*

using System;
using System.Collections.Generic;

namespace kt12
{
    class SimpleCalculator
    {
        static Dictionary<char, int> priorities = new Dictionary<char, int>
    {
        {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2}
    };

        static void Main()
        {
            Console.Write("answer ");
            string input = Console.ReadLine();

            var postfix = ConvertToPostfix(input);
            double result = CalculatePostfix(postfix);

            Console.WriteLine($"result {result}");
        }

        static List<string> ConvertToPostfix(string expr)
        {
            var output = new List<string>();
            var operators = new Stack<char>();
            string number = "";

            foreach (char c in expr)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else if (priorities.ContainsKey(c))
                {
                    if (number != "")
                    {
                        output.Add(number);
                        number = "";
                    }

                    while (operators.Count > 0 && priorities[operators.Peek()] >= priorities[c])
                    {
                        output.Add(operators.Pop().ToString());
                    }
                    operators.Push(c);
                }
            }

            if (number != "") output.Add(number);
            while (operators.Count > 0) output.Add(operators.Pop().ToString());

            return output;
        }

        static double CalculatePostfix(List<string> postfix)
        {
            var stack = new Stack<double>();

            foreach (string token in postfix)
            {
                if (double.TryParse(token, out double num))
                {
                    stack.Push(num);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push(a / b); break;
                    }
                }
            }

            return stack.Pop();
        }
    }
}

*/

using System;
using System.Collections.Generic;

namespace kt12
{
    class SimpleCountryInfo
    {
        static void Main()
        {
            Dictionary<string, string> capitals = new Dictionary<string, string>();
            capitals.Add("Россия", "Москва");
            capitals.Add("США", "Вашингтон");
            capitals.Add("Германия", "Берлин");

            Dictionary<string, int> populations = new Dictionary<string, int>();
            populations.Add("Россия", 146);
            populations.Add("США", 331);
            populations.Add("Германия", 83);

            Console.Write("write name of country ");
            string country = Console.ReadLine();

            if (capitals.ContainsKey(country) && populations.ContainsKey(country))
            {
                Console.WriteLine($"capital: {capitals[country]}");
                Console.WriteLine($"population: {populations[country]} millions");
            }
            else
            {
                Console.WriteLine("country doesnt exists");
            }
        }
    }
}