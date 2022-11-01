using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> charOccurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char curChar = input[i];
                if (!charOccurrences.ContainsKey(curChar))
                {
                    charOccurrences.Add(curChar, 0);
                }
                charOccurrences[curChar]++;
            }

            foreach (var character in charOccurrences)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
