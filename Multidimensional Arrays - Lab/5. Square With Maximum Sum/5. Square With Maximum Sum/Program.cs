using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rows = size[0];
            var cols = size[1];
            int maxSum = int.MinValue;
            int[] startIndexMaxSum = new int[2];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
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

                    if ((x1 + x2 + x3 + x4) > maxSum)
                    {
                        maxSum = x1 + x2 + x3 + x4;
                        startIndexMaxSum[0] = row;
                        startIndexMaxSum[1] = col;
                    }
                }
            }

            bool isFound = false;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == startIndexMaxSum[0] && col == startIndexMaxSum[1])
                    {
                        Console.WriteLine($"{ matrix[row, col]} {matrix[row, col + 1]}");
                        Console.WriteLine($"{matrix[row + 1, col]} {matrix[row + 1, col + 1]}");
                        isFound = true;
                        break;
                    }
                }

                if (isFound) break;
            }

            Console.WriteLine(maxSum);
        }
    }
}
