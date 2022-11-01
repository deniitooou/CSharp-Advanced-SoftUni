using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static Func<string, int, bool> isEqual = (w, x) => w.Length <= x;

        static void Main(string[] args)
        {
            int thresHold = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isEqual(w, thresHold))
                ));
        }
    }
}
