using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int foodQuantity = 0;
            List<int> snakePosition = new List<int>();
            List<int> burrowOne = new List<int>();
            List<int> burrowTwo = new List<int>();
            SetPositions(matrix, ref snakePosition, ref burrowOne, ref burrowTwo, n);

            string input = Console.ReadLine();

            while (true)
            {
                int snakeRow = snakePosition[0];
                int snakeCol = snakePosition[1];
                matrix[snakePosition[0], snakePosition[1]] = '.';

                NextPosition(input, ref snakeRow, ref snakeCol);

                if (snakeRow >= 0 && snakeRow < n && snakeCol >= 0 && snakeCol < n)
                {

                    if (matrix[snakeRow, snakeCol] == 'B' && burrowOne[0] == snakeRow && burrowOne[1] == snakeCol) 
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakePosition[0] = burrowTwo[0];
                        snakePosition[1] = burrowTwo[1];
                    }
                    else if (matrix[snakeRow, snakeCol] == 'B' && burrowTwo[0] == snakeRow && burrowTwo[1] == snakeCol)
                    {
                        matrix[snakeRow, snakeRow] = '.';
                        snakePosition[0] = burrowOne[0];
                        snakePosition[1] = burrowOne[1];
                    }
                    else if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodQuantity++;
                        snakePosition[0] = snakeRow;
                        snakePosition[1] = snakeCol;
                    }
                    else
                    {
                        snakePosition[0] = snakeRow;
                        snakePosition[1] = snakeCol;
                    }
                }
                else if (!(snakeRow >= 0 && snakeRow < n && snakeCol >= 0 && snakeCol < n))
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                if (foodQuantity >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void NextPosition(string input, ref int snakeRow, ref int snakeCol)
        {
            switch (input)
            {
                case "left":
                    snakeCol--;
                    break;
                case "up":
                    snakeRow--;
                    break;
                case "right":
                    snakeCol++;
                    break;
                case "down":
                    snakeRow++;
                    break;
            }
        }

        private static void SetPositions(char[,] matrix, ref List<int> snakePosition, ref List<int> burrowOne, ref List<int> burrowTwo, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var currRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currRow[j];

                    if (currRow[j] == 'S')
                    {
                        snakePosition.Add(i);
                        snakePosition.Add(j);
                    }
                    if (currRow[j] == 'B')
                    {
                        if (burrowOne.Count() == 2)
                        {
                            burrowTwo.Add(i);
                            burrowTwo.Add(j);
                        }
                        else
                        {
                            burrowOne.Add(i);
                            burrowOne.Add(j);
                        }
                    }
                }
            }
        }
    }
}
