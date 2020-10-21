using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            var traficQueue = new Queue<string>();
            var car = new Queue<char>();

            int totalCarsPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    if (traficQueue.Any())
                    {
                        string carName = traficQueue.Peek();
                        car = new Queue<char>(traficQueue.Dequeue());

                        for (int i = 0; i < greenLightDuration; i++)
                        {
                            if (car.Any())
                            {
                                car.Dequeue();
                            }
                            else
                            {
                                if (traficQueue.Any())
                                {
                                    totalCarsPassed++;
                                    carName = traficQueue.Peek();
                                    car = new Queue<char>(traficQueue.Dequeue());
                                    car.Dequeue();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (car.Any())
                        {
                            for (int i = 0; i < freeWindowDuration; i++)
                            {
                                if (car.Any())
                                {
                                    car.Dequeue();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (car.Any())
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carName} was hit at {car.Peek()}.");
                            break;
                        }
                        totalCarsPassed++;
                    }
                }
                else
                {
                    traficQueue.Enqueue(input);
                }
            }
            if (!car.Any())
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
