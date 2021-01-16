using System;
using System.Collections.Generic;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cmdCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            List<int> playerPosition = new List<int>();
            ReadMatrix(n, matrix, playerPosition);

            bool playerWon = false;


            for (int i = 0; i < cmdCount; i++)
            {
                string input = Console.ReadLine();

                matrix[playerPosition[0], playerPosition[1]] = '-';
                int currRow = playerPosition[0];
                int currCol = playerPosition[1];
                Movement(input, ref currRow, ref currCol);

                CheckIfOut(n, input, ref currRow, ref currCol);

                if (matrix[currRow, currCol] == 'F')
                {
                    matrix[currRow, currCol] = 'f';
                    playerWon = true;
                    break;
                }
                else if (matrix[currRow, currCol] == 'B')
                {
                    Movement(input, ref currRow, ref currCol);
                    CheckIfOut(n, input, ref currRow, ref currCol);

                    if (matrix[currRow, currCol] == 'F')
                    {
                        matrix[currRow, currCol] = 'f';
                        playerWon = true;
                        break;
                    }
                    playerPosition[0] = currRow;
                    playerPosition[1] = currCol;

                }
                else if (matrix[currRow, currCol] == 'T')
                {
                    continue;
                }
                else
                {
                    matrix[currRow, currCol] = 'f';
                    playerPosition[0] = currRow;
                    playerPosition[1] = currCol;
                }
            }

            Console.WriteLine(playerWon ? "Player won!" : "Player lost!");
            PrintMatrix(matrix);
        }

        public static void ReadMatrix(int n, char[,] matrix, List<int> playerPosition)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        playerPosition.Add(row);
                        playerPosition.Add(col);
                    }
                }
            }
        }

        public static void PrintMatrix(char[,] matrix)
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
        private static void Movement(string input, ref int currRow, ref int currCol)
        {
            switch (input)
            {
                case "up":
                    currRow--;
                    break;
                case "down":
                    currRow++;
                    break;
                case "left":
                    currCol--;
                    break;
                case "right":
                    currCol++;
                    break;
            }
        }
        public static void CheckIfOut(int n, string input, ref int currRow, ref int currCol)
        {
            if (currRow < 0 || currCol < 0 || currRow >= n || currCol >= n)
            {
                switch (input)
                {
                    case "up":
                        currRow = n - 1;
                        break;
                    case "down":
                        currRow = 0;
                        break;
                    case "left":
                        currCol = n - 1;
                        break;
                    case "right":
                        currCol = 0;
                        break;
                }

            }
        }
    }
}
