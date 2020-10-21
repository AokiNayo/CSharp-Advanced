using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[matrixArgs[0], matrixArgs[1]];

            FillMatrix(matrix);

            int equalCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row + 1, col] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col + 1] == matrix[row + 1, col + 1])
                    {
                        equalCount++;
                    }
                }
            }
            Console.WriteLine(equalCount);
        }

        public static string[,] FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
}
