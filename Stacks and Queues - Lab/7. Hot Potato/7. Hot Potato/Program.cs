using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            Queue<string> players = new Queue<string>(input);

            int number = int.Parse(Console.ReadLine());

            while (players.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                    players.Enqueue(players.Dequeue());

                Console.WriteLine($"Removed {players.Dequeue()}");
            }

            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
