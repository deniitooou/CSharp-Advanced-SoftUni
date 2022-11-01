using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            HashSet<string> setOfNames = new HashSet<string>();

            for (int i = 0; i < inputCount; i++)
            {
                string curName = Console.ReadLine();
                setOfNames.Add(curName);
            }

            Console.WriteLine($"{string.Join("\n", setOfNames)}");
        }
    }
}
