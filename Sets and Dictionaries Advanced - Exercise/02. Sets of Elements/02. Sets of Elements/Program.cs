using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int firstSetCnt = inputInfo[0];
            int secondSetCnt = inputInfo[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetCnt; i++)
            {
                int curNum = int.Parse(Console.ReadLine());
                firstSet.Add(curNum);
            }
            for (int i = 0; i < secondSetCnt; i++)
            {
                int curNum = int.Parse(Console.ReadLine());
                secondSet.Add(curNum);
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
