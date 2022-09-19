using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothesStack = new Stack<int>(clothes);

            int rackCapacity = int.Parse(Console.ReadLine());
            var racksCount = 1;
            var capacityLeft = rackCapacity;
            while (clothesStack.Count > 0)
            {
                var currentCloth = clothesStack.Peek();

                if (currentCloth <= capacityLeft)
                {
                    capacityLeft -= currentCloth;
                    clothesStack.Pop();
                }
                else
                {
                    racksCount++;
                    capacityLeft = rackCapacity;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
