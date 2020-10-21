using System;
using System.Linq;

namespace MultidemenshionArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int sum = 0;

            FillMatrix(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = sum + matrix[i, i];
            }

            Console.WriteLine(sum);
        }

        public static void FillMatrix(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }
        }
    }
}
