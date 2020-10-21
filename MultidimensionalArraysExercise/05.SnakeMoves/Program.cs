using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];

            char[,] matrix = new char[rows, cols];

            string input = Console.ReadLine();
            string direction = "Right";
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (count == input.Length)
                    {
                        count = 0;
                    }

                    if (direction == "Right")
                    {
                        matrix[row, col] = input[count];
                        count++;
                    }
                    else if (direction == "Left")
                    {
                        matrix[row, cols - 1 - col] = input[count];
                        count++;
                    }
                }
                if (row % 2 == 0)
                {
                    direction = "Left";
                }
                else
                {
                    direction = "Right";
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
