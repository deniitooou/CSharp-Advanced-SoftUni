using System;
using System.Collections.Generic;
using System.Linq;

namespace Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> miligramsOfCaffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalCaffeine = 0;

            while (miligramsOfCaffeine.Any() && energyDrinks.Any())
            {
                int currentCaffeine = miligramsOfCaffeine.Peek();
                int currentEnergyDrinks = energyDrinks.Peek();
                int sum = currentEnergyDrinks * currentCaffeine;

                if (totalCaffeine + sum <= 300)
                {
                    energyDrinks.Dequeue();
                    totalCaffeine += sum;
                    miligramsOfCaffeine.Pop();
                }
                else
                {
                    miligramsOfCaffeine.Pop();
                    energyDrinks.Enqueue(energyDrinks.Dequeue());

                    if (totalCaffeine - 30 >= 0)
                    {
                        totalCaffeine -= 30;
                    }
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }
    }
}
