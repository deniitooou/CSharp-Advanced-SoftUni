using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Queue<int> numbers = new Queue<int>();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] % 2 == 0)
                    {
                        numbers.Enqueue(input[i]);
                    }
                }

                Console.WriteLine(string.Join(", ", numbers));
            }
        }
    }
}
