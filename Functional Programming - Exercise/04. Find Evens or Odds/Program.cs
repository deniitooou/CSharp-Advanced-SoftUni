using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string condition = Console.ReadLine();

            for (int i = input[0]; i <= input[1]; i++)
            {
                if (condition == "odd")
                {
                    if (!isEven(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
                else
                {
                    if (isEven(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }
    }
}
