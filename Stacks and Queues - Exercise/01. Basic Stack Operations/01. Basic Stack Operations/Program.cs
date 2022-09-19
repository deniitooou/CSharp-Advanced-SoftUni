using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] countOfOperations = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numToFind = countOfOperations[2];
            int countOfNumsToPop = countOfOperations[1];

            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var stackOfNums = new Stack<int>(nums);

            for (int i = 0; i < countOfNumsToPop; i++)
            {
                stackOfNums.Pop();
            }

            if (stackOfNums.Contains(numToFind))
            {
                Console.WriteLine("true");
            }
            else if (stackOfNums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stackOfNums.Min());
            }
        }
    }
}
