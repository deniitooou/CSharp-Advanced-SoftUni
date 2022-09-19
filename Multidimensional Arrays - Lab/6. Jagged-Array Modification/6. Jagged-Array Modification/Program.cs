using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++) matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();
                var cmd = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);
                var val = int.Parse(tokens[3]);

                if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    Console.WriteLine("Invalid coordinates");
                else
                {
                    if (cmd == "Add") matrix[row][col] += val;
                    else if (cmd == "Subtract") matrix[row][col] -= val;
                }


                input = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++) Console.WriteLine(String.Join(" ", matrix[row]));
        }
    }
}
