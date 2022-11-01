using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = x => Console.WriteLine($"{x.Length}\r\n{x.Select(int.Parse).Sum()}");
            print(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
