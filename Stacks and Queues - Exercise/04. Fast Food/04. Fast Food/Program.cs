using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var myQ = new Queue<int>(orders);

            int sum = 0;

            Console.WriteLine(myQ.Max());

            while (myQ.Count > 0)
            {
                int first = myQ.Peek();

                sum += first;

                if (sum <= foodQuantity)
                {
                    myQ.Dequeue();
                }
                else
                {
                    int[] arr = myQ.ToArray();
                    Console.WriteLine("Orders left: " + string.Join(" ", arr));
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
