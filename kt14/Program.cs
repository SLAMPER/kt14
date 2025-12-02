using System;
using System.Collections.Generic;

namespace kt14
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