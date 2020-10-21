using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> examPass = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> examsResult = new Dictionary<string, Dictionary<string, int>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] data = input.Split(":");

                if (!examPass.ContainsKey(data[0]))
                {
                    examPass.Add(data[0], data[1]);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] data = input.Split("=>");

                string contest = data[0];
                string password = data[1];
                string student = data[2];
                int studentPoints = int.Parse(data[3]);

                if (examPass.ContainsKey(contest) && examPass[contest] == password)
                {
                    if (!examsResult.ContainsKey(student))
                    {
                        examsResult.Add(student, new Dictionary<string, int>());
                        examsResult[student].Add(contest, studentPoints);
                    }
                    else
                    {
                        if (!examsResult[student].ContainsKey(contest))
                        {
                            examsResult[student].Add(contest, studentPoints);
                        }
                        else if (examsResult[student][contest] < studentPoints)
                        {
                            examsResult[student][contest] = studentPoints;
                        }
                    }
                }
            }

            foreach (var item in examsResult.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value).Take(1))
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
            }

            Console.WriteLine("Ranking:");

            foreach (var student in examsResult.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var item in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }

        }
    }
}
