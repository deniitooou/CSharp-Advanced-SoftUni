using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rows + 1][];

            for (int row = 0; row < rows; row++) triangle[row] = new long[row + 1];

            triangle[0][0] = 1;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            for (int row = 0; row < rows; row++) Console.WriteLine(String.Join(" ", triangle[row]));

        }
    }
}
