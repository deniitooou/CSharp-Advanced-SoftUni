using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<PetrolStation> stations = new Queue<PetrolStation>(capacity: n);

            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                PetrolStation currentStation = new PetrolStation { Fuel = data[0], DistanceToNext = data[1] };
                stations.Enqueue(currentStation);
            }

            int ans = -1;
            for (int i = 0; i < n; i++)
            {
                Queue<PetrolStation> newQueue = new Queue<PetrolStation>(stations);
                if (CanCompleteRoute(newQueue))
                {
                    ans = i;
                    break;
                }

                stations.Enqueue(stations.Dequeue());
            }

            Console.WriteLine(ans);
        }

        private static bool CanCompleteRoute(Queue<PetrolStation> stations)
        {
            int fuelInTank = 0;
            while (stations.Count > 0 && fuelInTank >= 0)
            {
                PetrolStation currentStation = stations.Dequeue();
                fuelInTank += currentStation.Fuel - currentStation.DistanceToNext;
            }

            return fuelInTank >= 0;
        }
    }

    public class PetrolStation
    {
        public int Fuel { get; set; }
        public int DistanceToNext { get; set; }
    }
}