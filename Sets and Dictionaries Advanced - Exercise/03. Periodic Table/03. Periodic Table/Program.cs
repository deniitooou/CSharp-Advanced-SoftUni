using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCnt = int.Parse(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();

            for (int line = 0; line < inputCnt; line++)
            {
                string[] tokens = Console.ReadLine().Split();
                for (int element = 0; element < tokens.Length; element++)
                {
                    set.Add(tokens[element]);
                }
            }
            Console.WriteLine(String.Join(" ", set));
        }
    }
}
