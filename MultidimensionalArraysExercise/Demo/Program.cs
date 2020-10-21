using System;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            FillMatrix(rows, cols, matrix);

            if (rows < 3 || cols < 3)
            {
                Console.WriteLine($"Sum = {0}");
                return;
            }

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            GetMaxSum(rows, cols, matrix, ref maxSum, ref maxRow, ref maxCol);
            PrintResult(matrix, maxSum, maxRow, maxCol);

        }

        private static void FillMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }

            }
        }

        private static void GetMaxSum(int rows, int cols, int[,] matrix, ref int maxSumMatrix, ref int firstMaxRow, ref int firsrMaxCol)
        {
            for (int row = 0; row < rows - 2; row++)
            {
                int currentSum = 0;

                for (int col = 0; col < cols - 2; col++)
                {
                    int firstRow = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int secondRow = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int thirdRow = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    currentSum = firstRow + secondRow + thirdRow;

                    if (currentSum > maxSumMatrix)
                    {
                        maxSumMatrix = currentSum;
                        firsrMaxCol = col;
                        firstMaxRow = row;
                    }

                }
            }
        }

        private static void PrintResult(int[,] matrix, int maxSumMatrix, int firstMaxRow, int firsrMaxCol)
        {
            Console.WriteLine($"Sum = {maxSumMatrix}");

            for (int row = firstMaxRow; row < firstMaxRow + 3; row++)
            {
                for (int col = firsrMaxCol; col < firsrMaxCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
