using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            bool isHit = false;
            int passedCarsCount = 0;

            var input = Console.ReadLine();
            while (input != "END" && !isHit)
            {

                if (input != "green") cars.Enqueue(input);
                else
                {
                    var greenLightSecondsLeft = greenLightDuration;
                    var freeWindowSecondsLeft = freeWindowDuration;

                    while (greenLightSecondsLeft > 0 && !isHit && cars.Count > 0)
                    {
                        var currentCar = cars.Dequeue();

                        if (currentCar.Length < greenLightSecondsLeft)
                        {
                            greenLightSecondsLeft -= currentCar.Length;
                            passedCarsCount++;
                        }

                        else if (currentCar.Length <= greenLightSecondsLeft + freeWindowSecondsLeft)
                        {
                            passedCarsCount++;
                            break;
                        }

                        else
                        {
                            var indexOfCrash = greenLightSecondsLeft + freeWindowSecondsLeft;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[indexOfCrash]}.");
                            isHit = true;
                        }
                    }
                }

                if (!isHit)
                    input = Console.ReadLine();
            }

            if (!isHit)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
            }
        }
    }
}
