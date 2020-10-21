using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            FillMatrix(matrix);

            string data = String.Empty;

            while ((data = Console.ReadLine()) != "END")
            {
                string[] dataArgs = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = dataArgs[0];

                if (command == "swap" && dataArgs.Length == 5)
                {
                    int firstRow = int.Parse(dataArgs[1]);
                    int firstCol = int.Parse(dataArgs[2]);
                    int secondRow = int.Parse(dataArgs[3]);
                    int secondCol = int.Parse(dataArgs[4]);

                    if (firstRow >= 0 && firstCol >= 0 && secondRow >= 0 && secondCol >= 0
                            && firstRow < matrix.GetLength(0)
                            && firstCol < matrix.GetLength(1)
                            && secondRow < matrix.GetLength(0)
                            && secondCol < matrix.GetLength(1))
                    {
                        string temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

        }

        public static string[,] FillMatrix(string[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }
            return matrix;
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
