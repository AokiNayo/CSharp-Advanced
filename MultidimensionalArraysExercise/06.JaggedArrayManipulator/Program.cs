using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            FillArray(n, jaggedArray);
            AnalyzeArray(jaggedArray);

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                double value = double.Parse(cmdArgs[3]);

                if (row >= 0 && col >= 0 && jaggedArray[row].Length >= col)
                {
                    switch (cmdArgs[0])
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }
            }
            PrintArray(jaggedArray);
        }

        private static void FillArray(int n, double[][] jaggedArray)
        {
            for (int row = 0; row < n; row++)
            {
                double[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = data;
            }
        }
        private static void AnalyzeArray(double[][] jaggedArray)
        {
            for (int row = 1; row < jaggedArray.Length; row++)
            {
                if (jaggedArray[row - 1].Length == jaggedArray[row].Length)
                {
                    jaggedArray[row - 1] = jaggedArray[row - 1].Select(x => x * 2).ToArray();
                    jaggedArray[row] = jaggedArray[row].Select(x => x * 2).ToArray();
                }
                else if (jaggedArray[row - 1].Length != jaggedArray[row].Length)
                {
                    jaggedArray[row - 1] = jaggedArray[row - 1].Select(x => x / 2).ToArray();
                    jaggedArray[row] = jaggedArray[row].Select(x => x / 2).ToArray();
                }
            }
        }
        private static void PrintArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }

    }
}
