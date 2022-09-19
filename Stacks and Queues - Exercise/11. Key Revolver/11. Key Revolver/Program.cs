using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            var bulletsList = Console.ReadLine().Split().Select(int.Parse).ToList();
            bulletsList.Reverse();
            var bullets = new Queue<int>(bulletsList);

            var locksList = Console.ReadLine().Split().Select(int.Parse).ToList();
            locksList.Reverse();
            var locks = new Stack<int>(locksList);

            int inteligenceValue = int.Parse(Console.ReadLine());

            var barrelCount = 0;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                var currentLock = locks.Peek();
                var currentBullet = bullets.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Pop();
                    bullets.Dequeue();
                    inteligenceValue -= bulletPrice;
                    barrelCount++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    inteligenceValue -= bulletPrice;
                    bullets.Dequeue();
                    barrelCount++;
                }

                if (barrelCount == barrelSize && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    barrelCount = 0;
                }
            }

            if (locks.Count > 0)
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            else
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligenceValue}");
        }
    }
}
