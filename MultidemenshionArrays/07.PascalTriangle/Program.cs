using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] array = new long[n][];
            int cols = 1;

            for (int row = 0; row < array.Length; row++)
            {
                array[row] = new long[cols];
                array[row][0] = 1;
                array[row][array[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < array[row].Length - 1; col++)
                    {
                        long[] prevRow = array[row - 1];
                        long firstNum = prevRow[col];
                        long secondNum = prevRow[col - 1];

                        array[row][col] = firstNum + secondNum;
                    }
                }
                cols++;
            }

            foreach (var item in array)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
