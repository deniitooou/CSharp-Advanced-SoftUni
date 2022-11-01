using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string[], int> cmin = arr => arr.Select(int.Parse).Min();
            Console.WriteLine(cmin(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
