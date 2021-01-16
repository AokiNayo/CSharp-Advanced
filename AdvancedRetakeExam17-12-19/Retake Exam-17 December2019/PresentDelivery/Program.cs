using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            List<int> santaPosition = new List<int>();

            int niceKids = 0;
            int presentGiven = 0;

            ReadMatrix(n, matrix, santaPosition, ref niceKids);

            int happyKids = niceKids;

            string input = Console.ReadLine();

            while (input != "Christmas morning")
            {
                matrix[santaPosition[0], santaPosition[1]] = "-";
                int row = santaPosition[0];
                int col = santaPosition[1];

                Movement(input, ref row, ref col);

                if (matrix[row, col] == "V")
                {
                    presentCount--;
                    presentGiven++;
                    niceKids--;
                }
                else if (matrix[row, col] == "C")
                {
                    HappyTime(ref presentCount, ref presentGiven, matrix, ref niceKids, row, col);
                }

                matrix[row, col] = "S";
                santaPosition[0] = row;
                santaPosition[1] = col;

                if (presentCount == 0)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(presentCount == 0 ? $"Santa ran out of presents!" : null);
            PrintMatrix(n, matrix);
            Console.WriteLine(niceKids == 0 ? $"Good job, Santa! {happyKids} happy nice kid/s." : $"No presents for {niceKids} nice kid/s.");
        }

        private static void PrintMatrix(int n, string[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void HappyTime(ref int presentCount, ref int presentGiven, string[,] matrix, ref int niceKids, int row, int col)
        {
            if (matrix[row - 1, col] == "V")
            {
                niceKids--;
                presentCount--;
                presentGiven++;

                matrix[row - 1, col] = "-"; // up
            }
            else if (matrix[row - 1, col] == "X")
            {
                presentCount--;
                presentGiven++;

                matrix[row - 1, col] = "-";
            }
            if (matrix[row + 1, col] == "V")
            {
                niceKids--;
                presentCount--;
                presentGiven++;

                matrix[row + 1, col] = "-";
            }
            else if (matrix[row + 1, col] == "X")
            {
                presentCount--;
                presentGiven++;
                matrix[row + 1, col] = "-";
            }
            if (matrix[row, col - 1] == "V")
            {
                niceKids--;
                presentCount--;
                presentGiven++;

                matrix[row, col - 1] = "-";

            }
            else if (matrix[row, col - 1] == "X")
            {
                presentCount--;
                presentGiven++;

                matrix[row, col - 1] = "-";

            }
            if (matrix[row, col + 1] == "V")
            {
                niceKids--;
                presentCount--;
                presentGiven++;

                matrix[row, col + 1] = "-";
            }
            else if (matrix[row, col + 1] == "X")
            {
                presentCount--;
                presentGiven++;

                matrix[row, col + 1] = "-";
            }
        }

        private static void Movement(string input, ref int row, ref int col)
        {
            switch (input)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }
        }

        static void ReadMatrix(int n, string[,] matrix, List<int> santaPosition, ref int niceKids)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == "S")
                    {
                        santaPosition.Add(row);
                        santaPosition.Add(col);
                    }
                    if (input[col] == "V")
                    {
                        niceKids++;
                    }

                }
            }
        }
    }
}
