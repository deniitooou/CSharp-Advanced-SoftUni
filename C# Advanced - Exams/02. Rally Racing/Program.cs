using System;
using System.Linq;

namespace Rally_Racing
{
    internal class Program
    {
        private static int rowOfCars = 0;
        private static int colOfCars = 0;
        private static int tunelRowFirst = 0;
        private static int tunelRowSecond = 0;
        private static int tunelColFirst = 0;
        private static int tunelColSecond = 0;

        private static string racingNumbers = string.Empty;
        private static int totalKm = 0;
        private static bool hasFinished = false;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            racingNumbers = Console.ReadLine();
            int tunnels = 0;

            for (int rows = 0; rows < size; rows++)
            {
                char[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = currentRow[cols];

                    if (currentRow[cols] == 'T')
                    {
                        if (tunnels == 0)
                        {
                            tunelRowFirst = rows;
                            tunelColFirst = cols;
                            tunnels++;
                        }
                        else
                        {
                            tunelRowSecond = rows;
                            tunelColSecond = cols;
                        }
                    }
                }
            }

            string cmnd = Console.ReadLine();

            while (cmnd != "End")
            {
                switch (cmnd)
                {
                    case "left":
                        Move(0, -1, matrix);
                        break;
                    case "right":
                        Move(0, 1, matrix);
                        break;
                    case "up":
                        Move(-1, 0, matrix);
                        break;
                    case "down":
                        Move(1, 0, matrix);
                        break;
                }

                if (hasFinished)
                {
                    break;
                }

                cmnd = Console.ReadLine();
            }


            if (hasFinished)
            {
                Console.WriteLine($"Racing car {racingNumbers} finished the stage!");

            }

            else
            {
                Console.WriteLine($"Racing car {racingNumbers} DNF.");
            }

            Console.WriteLine($"Distance covered {totalKm} km.");

            matrix[rowOfCars, colOfCars] = 'C';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }

        private static void Move(int row, int col, char[,] matrix)
        {
            if (!IsValid(rowOfCars + row, colOfCars + col, matrix)) return;

            if (matrix[rowOfCars + row, colOfCars + col] == 'T')
            {
                if (rowOfCars + row == tunelRowFirst && colOfCars + col == tunelColFirst)
                {
                    matrix[rowOfCars + row, colOfCars + col] = '.';
                    rowOfCars = tunelRowSecond;
                    colOfCars = tunelColSecond;
                    matrix[rowOfCars, colOfCars] = '.';
                }
                else
                {
                    matrix[rowOfCars + row, colOfCars + col] = '.';
                    rowOfCars = tunelRowFirst;
                    colOfCars = tunelColFirst;
                    matrix[rowOfCars, colOfCars] = '.';
                }

                totalKm += 30;
            }
            else if (matrix[rowOfCars + row, colOfCars + col] == 'F')
            {
                hasFinished = true;
                rowOfCars += row;
                colOfCars += col;
                totalKm += 10;
            }
            else
            {
                rowOfCars += row;
                colOfCars += col;
                totalKm += 10;
            }
        }

        private static bool IsValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}