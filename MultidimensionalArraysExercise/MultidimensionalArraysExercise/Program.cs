using System;
using System.Linq;

namespace MultidimensionalArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillMatrix(matrix);

            //int D1 = PrimaryDiagonal(matrix);
            //int D2 = SecondaryDiagonal(matrix);
            //int result = Math.Abs(D1 - D2);

            int D1 = 0;
            int D2 = 0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        D1 += matrix[row, col];
                    }
                    if (col == n - 1 - row)
                    {
                        D2 += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(D1-D2));


        }

        public static int[,] FillMatrix(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }
            return matrix;
        }
        public static int PrimaryDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, row];
            }
            return sum;
        }
        public static int SecondaryDiagonal(int[,] matrix)
        {
            int sum = 0;
            int col = matrix.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, col];
                col--;
            }
            return sum;
        }

    }
}
