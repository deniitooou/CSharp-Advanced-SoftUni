using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((string.Join(", ",
                 Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .Where(x => x % 2 == 0)
                 .OrderBy(x => x)
                )));
        }
    }
}
