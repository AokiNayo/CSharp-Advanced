using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[row] = new int[nums.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = nums[col];
                }
            }

            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] cmdArgs = cmd.Split();
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if ((row >= 0 && col >= 0) && row <= matrix.Length - 1 && col <= matrix.Length)
                {
                    switch (cmdArgs[0])
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;
                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                cmd = Console.ReadLine();
            }
            foreach (var item in matrix)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
