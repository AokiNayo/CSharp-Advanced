using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            List<int> snake = new List<int>();
            List<int> burrowOne = new List<int>();
            List<int> burrowTwo = new List<int>();

            SetPositionsAndGetPositions(n, matrix, snake, burrowOne, burrowTwo);

            int foodQuantity = 0;
            bool gameOver = false;

            while (true)
            {
                if (foodQuantity >= 10)
                {
                    break;
                }
                string input = Console.ReadLine();

                int snakeRow = snake[0];
                int snakeCol = snake[1];
                switch (input)
                {
                    case "left": snakeCol--;
                        break;
                    case "up": snakeRow--;
                        break;
                    case "right": snakeCol++;
                        break;
                    case "down": snakeRow++;
                        break;
                }

                if (snakeCol < 0 || snakeCol > matrix.GetLength(1) - 1 || snakeRow < 0 || snakeRow > matrix.GetLength(0) - 1)
                {
                    matrix[snake[0], snake[1]] = '.';
                    gameOver = true;
                    break;
                }

                if (matrix[snakeRow, snakeCol] == 'B' && burrowOne[0] == snakeRow && burrowOne[1] == snakeCol) // 
                {
                    // Next position
                    matrix[snakeRow, snakeCol] = '.'; 
                    // Swap Exit B with S
                    matrix[burrowTwo[0], burrowTwo[1]] = matrix[snake[0], snake[1]]; 
                    // Leaves trail at the last S position
                    matrix[snake[0], snake[1]] = '.';
                    // Swap S position in S List
                    snake[0] = burrowTwo[0];
                    snake[1] = burrowTwo[1];
                }
                else if (matrix[snakeRow, snakeCol] == 'B' && burrowTwo[0] == snakeRow && burrowTwo[1] == snakeCol)
                {
                    // Next position
                    matrix[snakeRow, snakeCol] = '.';
                    // Swap Exit B with S
                    matrix[burrowOne[0], burrowOne[1]] = matrix[snake[0], snake[1]];
                    // Leaves trail at the last S position
                    matrix[snake[0], snake[1]] = '.';
                    // Swap S position in S List
                    snake[0] = burrowOne[0];
                    snake[1] = burrowOne[1];
                }
                else if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                    // Next position
                    matrix[snakeRow, snakeCol] = matrix[snake[0], snake[1]];
                    matrix[snake[0], snake[1]] = '.';
                    snake[0] = snakeRow;
                    snake[1] = snakeCol;
                }
                else
                {
                    matrix[snakeRow, snakeCol] = matrix[snake[0], snake[1]];
                    matrix[snake[0], snake[1]] = '.';
                    snake[0] = snakeRow;
                    snake[1] = snakeCol;
                }

            }
            Console.WriteLine(gameOver ? "Game over!" : "You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
            }
        }

        private static void SetPositionsAndGetPositions(int n, char[,] matrix, List<int> snake, List<int> burrowOne, List<int> burrowTwo)
        {
            for (int i = 0; i < n; i++)
            {
                string rows = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rows[j];

                    if (rows[j] == 'S')
                    {
                        snake.Add(i);
                        snake.Add(j);
                    }
                    else if (rows[j] == 'B')
                    {
                        if (burrowOne.Count == 2)
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
