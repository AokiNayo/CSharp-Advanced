using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            FillMatrix(matrix);

            if (matrix.GetLength(0) < 3 || matrix.GetLength(1) < 3)
            {
                Console.WriteLine($"Sum = {0}");
                return;
            }

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            GetMaxSum(matrix, ref maxSum, ref maxRow, ref maxCol);
            PrintResult(matrix, maxSum, maxRow, maxCol);
        }

        private static void GetMaxSum(int[,] matrix, ref int maxSum, ref int maxRow, ref int maxCol)
        {
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                int currentSum = 0;

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int firstRow = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    int secondRow = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    int thirdRow = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    currentSum = firstRow + secondRow + thirdRow;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
        }

        public static int[,] FillMatrix(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }
            return matrix;
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
