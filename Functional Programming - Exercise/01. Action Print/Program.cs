using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine,
               Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               ));
        }
    }
}
