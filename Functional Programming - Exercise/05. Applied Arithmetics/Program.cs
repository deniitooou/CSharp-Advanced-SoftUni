using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static Func<int, int> add = x => ++x;
        static Func<int, int> subtract = x => --x;
        static Func<int, int> multiply = x => x * 2;
        static Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            InputCommand(Console.ReadLine(), numbers);

        }

        private static void InputCommand(string command, int[] numbers)
        {
            switch (command)
            {
                case "add":
                    numbers = numbers.Select(x => add(x)).ToArray();
                    break;
                case "subtract":
                    numbers = numbers.Select(x => subtract(x)).ToArray();
                    break;
                case "multiply":
                    numbers = numbers.Select(x => multiply(x)).ToArray();
                    break;
                case "print":
                    print(numbers);
                    break;
                case "end":
                    return;
            }
            InputCommand(Console.ReadLine(), numbers);
        }
    }
}
