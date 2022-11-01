using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n.Insert(0, "Sir "))
                ));
        }
    }
}
