using System;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            Worm worm = new Worm();

            ReadMatrix(n, matrix, worm);

            string input = Console.ReadLine();

            while (input != "end")
            {

                matrix[worm.Row, worm.Col] = '-';
                int currRow = worm.Row;
                int currCol = worm.Col;

                Movement(input, ref currRow, ref currCol);

                if (currRow >= 0 && currRow < n && currCol >= 0 && currCol < n)
                {
                    if (Char.IsLetter(matrix[currRow, currCol]))
                    {
                        text += $"{matrix[currRow, currCol]}";
                    }

                    matrix[currRow, currCol] = 'P';
                    worm.Row = currRow;
                    worm.Col = currCol;
                }
                else
                {
                    if (text.Length != 0)
                    {
                        text = text.Remove(text.Length - 1);
                        matrix[worm.Row, worm.Col] = 'P';
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(text);

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

        private static void ReadMatrix(int n, char[,] matrix, Worm worm)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        worm.Row = row;
                        worm.Col = col;
                    }
                }
            }
        }

        class Worm
        {
            public int Row { get; set; }
            public int Col { get; set; }

        }
    }
}
