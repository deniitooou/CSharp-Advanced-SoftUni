using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = size[0];
            var cols = size[1];
            int maxSum = 0;
            int[] startIndexMaxSum = new int[2];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var x1 = matrix[row, col];
                    var x2 = matrix[row, col + 1];
                    var x3 = matrix[row, col + 2];
                    var x4 = matrix[row + 1, col];
                    var x5 = matrix[row + 1, col + 1];
                    var x6 = matrix[row + 1, col + 2];
                    var x7 = matrix[row + 2, col];
                    var x8 = matrix[row + 2, col + 1];
                    var x9 = matrix[row + 2, col + 2];

                    if ((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) > maxSum)
                    {
                        maxSum = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9;
                        startIndexMaxSum[0] = row;
                        startIndexMaxSum[1] = col;
                    }
                }
            }

            int rowIndex = startIndexMaxSum[0];
            int colIndex = startIndexMaxSum[1];

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[rowIndex, colIndex]} " +
                              $"{matrix[rowIndex, colIndex + 1]} " +
                              $"{matrix[rowIndex, colIndex + 2]}");

            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} " +
                              $"{matrix[rowIndex + 1, colIndex + 1]} " +
                              $"{matrix[rowIndex + 1, colIndex + 2]}");

            Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} " +
                              $"{matrix[rowIndex + 2, colIndex + 1]} " +
                              $"{matrix[rowIndex + 2, colIndex + 2]}");
        }
    }
}
