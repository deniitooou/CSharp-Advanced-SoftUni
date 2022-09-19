using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfCups = Console.ReadLine().Split().Select(int.Parse).ToList();
            listOfCups.Reverse();
            Stack<int> cups = new Stack<int>(listOfCups);

            var listOfBottles = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> bottles = new Stack<int>(listOfBottles);

            var wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                var currentCup = cups.Pop();
                var currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                    wastedWater += currentBottle - currentCup;
                else
                {
                    currentCup -= currentBottle;
                    cups.Push(currentCup);
                }
            }

            if (cups.Count > 0)
                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
            else if (bottles.Count > 0)
                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
