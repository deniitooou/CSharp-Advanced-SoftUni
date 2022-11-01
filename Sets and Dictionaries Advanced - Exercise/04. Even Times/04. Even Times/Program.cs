using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCnt = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int line = 0; line < inputCnt; line++)
            {
                int curNum = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(curNum))
                {
                    numbers.Add(curNum, 0);
                }
                numbers[curNum]++;
            }

            List<int> evenTimeNums = numbers
                .Where(number => number.Value % 2 == 0)
                .Select(number => number.Key)
                .ToList();
            Console.WriteLine(evenTimeNums[0]);
        }
    }
}
