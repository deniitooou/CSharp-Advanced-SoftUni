using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int[,] matrix = new int[x, x];

            for (int row = 0; row < x; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < x; col++)
                {
                    matrix[row, col] = line[col];
                }
                }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < x; row++)
            {
                primaryDiagonalSum += matrix[row, row];
            }
            for (int row = x - 1; row >= 0; row--)
            {
                secondaryDiagonalSum += matrix[x - row - 1, row];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
