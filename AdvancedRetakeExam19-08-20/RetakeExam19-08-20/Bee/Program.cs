using System;
using System.Collections.Generic;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n, n];

            List<int> beePosition = new List<int>();
            int pollinatedFlowers = 0;
            FillMatrix(n, territory, beePosition);


            string input = Console.ReadLine();

            while (input != "End")
            {
                territory[beePosition[0], beePosition[1]] = '.';
                int currRow = beePosition[0];
                int curCol = beePosition[1];

                NextPosition(input, ref currRow, ref curCol);

                if (currRow >= 0 && currRow < n && curCol >= 0 && curCol < n)
                {
                    if (territory[currRow, curCol] == 'f')
                    {
                        pollinatedFlowers++;
                        beePosition[0] = currRow;
                        beePosition[1] = curCol;
                    }
                    else if (territory[currRow, curCol] == 'O')
                    {
                        territory[currRow, curCol] = '.';
                        NextPosition(input, ref currRow, ref curCol);
                        if (territory[currRow, curCol] == 'f')
                        {
                            pollinatedFlowers++;
                        }
                        beePosition[0] = currRow;
                        beePosition[1] = curCol;
                    }
                    else
                    {
                        beePosition[0] = currRow;
                        beePosition[1] = curCol;
                    }
                }
                else if (!(currRow >= 0 && currRow < n && curCol >= 0 && curCol < n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                input = Console.ReadLine();
            }
            if (input == "End")
            {
                territory[beePosition[0], beePosition[1]] = 'B';
            }

            Console.WriteLine(pollinatedFlowers >= 5 ? $"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!" :
                $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(territory[i,j]);
                }
                Console.WriteLine();

            }
        }

        private static void NextPosition(string input, ref int currRow, ref int curCol)
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
                    curCol--;
                    break;
                case "right":
                    curCol++;
                    break;
            }
        }

        private static void FillMatrix(int n, char[,] territory, List<int> beePosition)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    territory[i, j] = input[j];

                    if (input[j] == 'B')
                    {
                        beePosition.Add(i);
                        beePosition.Add(j);
                    }
                }
            }
        }

    }
}
