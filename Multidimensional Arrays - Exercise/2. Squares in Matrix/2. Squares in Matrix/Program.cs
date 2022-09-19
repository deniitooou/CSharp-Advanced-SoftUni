using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = size[0];
            var cols = size[1];
            int count = 0;
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                string[] line = input.Split();
                for (int col = 0; col < cols; col++) matrix[row, col] = line[col];
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var x1 = matrix[row, col];
                    var x2 = matrix[row, col + 1];
                    var x3 = matrix[row + 1, col];
                    var x4 = matrix[row + 1, col + 1];

                    if (x1 == x2 && x1 == x3 && x1 == x4) count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
