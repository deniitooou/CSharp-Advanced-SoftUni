using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();
                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!map.ContainsKey(continent))
                {
                    map.Add(continent, new Dictionary<string, List<string>>());
                    map[continent].Add(country, new List<string>());
                    map[continent][country].Add(city);
                }
                else
                {
                    if (!map[continent].ContainsKey(country))
                        map[continent].Add(country, new List<string>());

                    map[continent][country].Add(city);
                }
            }

            PrintMap(map);
        }

        private static void PrintMap(Dictionary<string, Dictionary<string, List<string>>> map)
        {
            foreach (var continent in map)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var x in continent.Value)
                    Console.WriteLine($"  {x.Key} -> {string.Join(", ", x.Value)}");
            }
        }
    }
}
