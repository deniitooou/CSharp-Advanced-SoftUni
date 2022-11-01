using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static Func<int, int, bool> isDivisable = (x, y) => x % y == 0;
        static Action<List<int>> print = l => Console.Write(string.Join(" ", l));

        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> output = new List<int>();
            CheckNumbers(rangeEnd, dividers, output);
            print(output);
        }

        private static void CheckNumbers(int rangeEnd, int[] dividers, List<int> output)
        {
            for (int curNum = 1; curNum <= rangeEnd; curNum++)
            {
                bool isDivisableByAll = true;
                for (int i = 0; i < dividers.Length; i++)
                {
                    if (!isDivisable(curNum, dividers[i]))
                    {
                        isDivisableByAll = false;
                        break;
                    }
                }
                if (isDivisableByAll)
                {
                    output.Add(curNum);
                }
            }
        }
    }
}
