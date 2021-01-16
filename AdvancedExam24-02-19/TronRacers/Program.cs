using System;
using System.Collections.Generic;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int firstRow = 0;
            int firstCol = 0;

            int secondRow = 0;
            int secondCol = 0;

            ReadMatrix(n, matrix, ref firstRow, ref firstCol, ref secondRow, ref secondCol);

            while (true)
            {
                var input = Console.ReadLine().Split();

                string firstMovement = input[0]; // down
                string secondMovement = input[1]; // down

                PlayerMovements(ref firstRow, ref firstCol, ref secondRow, ref secondCol, firstMovement, secondMovement);

                CheckOutside(ref firstRow, ref firstCol, n);

                if (matrix[firstRow, firstCol] == 's')
                {
                    matrix[firstRow, firstCol] = 'x';
                    break;
                }

                matrix[firstRow, firstCol] = 'f';

                CheckOutside(ref secondRow, ref secondCol, n);
                if (matrix[secondRow, secondCol] == 'f')
                {
                    matrix[secondRow, secondCol] = 'x';
                    break;
                }

                matrix[secondRow, secondCol] = 's';
            }
            PrintMatrix(matrix);
        }

        private static void CheckOutside(ref int row, ref int col, int n)
        {
            if (row < 0)
                row = n - 1;
            if (row >= n)
                row = 0;
            if (col < 0)
                col = n - 1;
            if (col >= n)
                col = 0;
        }
        private static void PlayerMovements(ref int firstRow, ref int firstCol, ref int secondRow, ref int secondCol, string firstMovement, string secondMovement)
        {
            switch (firstMovement) // 1,3
            {
                case "up":
                    firstRow--;
                    break;
                case "down":
                    firstRow++;
                    break;
                case "left":
                    firstCol--;
                    break;
                case "right":
                    firstCol++;
                    break;
            }
            switch (secondMovement) // 2,2
            {
                case "up":
                    secondRow--;
                    break;
                case "down":
                    secondRow++;
                    break;
                case "left":
                    secondCol--;
                    break;
                case "right":
                    secondCol++;
                    break;
            }
        }

        private static void ReadMatrix(int n, char[,] matrix, ref int firstRow, ref int firstCol, ref int secondRow, ref int secondCol)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    if (input[col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }
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
