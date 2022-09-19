using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rows = data[0];
            var cols = data[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++) matrix[row, col] = rowData[col];
            }

            int colSum = 0;
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++) colSum += matrix[row, col];

                Console.WriteLine(colSum);
                colSum = 0;
            }
        }
    }
}
