using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            List<Flower> flowers = new List<Flower>();

            string cmd = Console.ReadLine();

            while (cmd != "Bloom Bloom Plow")
            {
                var cmdArr = cmd.Split();
                int row = int.Parse(cmdArr[0]);
                int col = int.Parse(cmdArr[1]);

                if (row >= 0 && row < size[0] && col >= 0 && col < size[1])
                {
                    matrix[row, col]++;
                    Flower currFlower = new Flower();
                    currFlower.Row = row;
                    currFlower.Col = col;
                    flowers.Add(currFlower);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                cmd = Console.ReadLine();
            }

            foreach (var item in flowers)
            {
                for (int upRow = item.Row - 1; upRow >= 0; upRow--)
                {
                    matrix[upRow, item.Col]++;
                }
                for (int downRow = item.Row + 1; downRow < matrix.GetLength(0); downRow++)
                {
                    matrix[downRow, item.Col]++;
                }
                for (int leftCol = item.Col - 1; leftCol >= 0; leftCol--)
                {
                    matrix[item.Row, leftCol]++;
                }
                for (int rightCol = item.Col + 1; rightCol < matrix.GetLength(1); rightCol++)
                {
                    matrix[item.Row, rightCol]++;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        class Flower
        {
            public int Row { get; set; }
            public int Col { get; set; }

        }
    }
}
