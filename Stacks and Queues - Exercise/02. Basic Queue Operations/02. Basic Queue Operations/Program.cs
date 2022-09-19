using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] countOfOperations = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numToFind = countOfOperations[2];
            int countOfNumsToPop = countOfOperations[1];

            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var stackOfNums = new Queue<int>(nums);

            for (int i = 0; i < countOfNumsToPop; i++)
                stackOfNums.Dequeue();

            if (stackOfNums.Contains(numToFind))
                Console.WriteLine("true");
            else if (stackOfNums.Count == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine(stackOfNums.Min());
        }
    }
}
