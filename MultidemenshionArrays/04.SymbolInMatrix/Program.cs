﻿using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            FillMatrix(matrix);

            char symbol = char.Parse(Console.ReadLine());
            bool noOccurence = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        noOccurence = false;
                        return;
                    }
                }
            }
            if (noOccurence)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }

        public static char[,] FillMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string input = Console.ReadLine();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }
            return matrix;
        }
    }
}
