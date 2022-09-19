using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++) matrix[row, col] = rowData[col];
            }

            int diagonalSum = 0;
            for (int i = 0; i < size; i++) diagonalSum += matrix[i, i];

            Console.WriteLine(diagonalSum);
        }
    }
}
