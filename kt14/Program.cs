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

            Console.WriteLine($"resuеlt {result}");
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