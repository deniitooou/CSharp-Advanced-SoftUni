using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split(", ");
                var cmd = data[0];
                var carNumber = data[1];

                if (cmd == "IN") cars.Add(carNumber);
                else if (cmd == "OUT") cars.Remove(carNumber);

                input = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                    Console.WriteLine(car);
            }
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}
