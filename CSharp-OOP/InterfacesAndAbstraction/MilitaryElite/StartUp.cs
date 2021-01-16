using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<ISoldier> soldiers = new List<ISoldier>();

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierRank = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];
                decimal salary = decimal.Parse(inputArgs[4]);

                if (soldierRank == typeof(Private).Name)
                {
                    Private @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(@private);
                }
                else if (soldierRank == typeof(LieutenantGeneral).Name)
                {
                    var test = inputArgs.Skip(5).ToArray();
                    List<IPrivate> list = new List<IPrivate>();

                    foreach (var item in test)
                    {
                        var test2 = int.Parse(item);
                        Private currentPrivate = (Private)soldiers.FirstOrDefault(x => x.ID == test2);
                        list.Add(currentPrivate);

                    }

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, list);
                    soldiers.Add(lieutenantGeneral);
                }
                else if (soldierRank == typeof(Engineer).Name)
                {
                    string corps = inputArgs[5];
                    var repairArgs = inputArgs.Skip(6).ToArray();

                    List<IRepairs> repairs = new List<IRepairs>();

                    for (int i = 0; i < repairArgs.Length; i += 2)
                    {
                        Repairs currentRepairs = new Repairs(repairArgs[i], int.Parse(repairArgs[i + 1]));
                        repairs.Add(currentRepairs);
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    soldiers.Add(engineer);
                }
                else if (soldierRank == typeof(Commando).Name)
                {
                    string corps = inputArgs[5];
                    var missionArgs = inputArgs.Skip(6).ToArray();

                    List<IMission> missions = new List<IMission>();

                    for (int i = 0; i < missionArgs.Length; i += 2)
                    {
                        Mission currentMission = new Mission(missionArgs[i], missionArgs[i + 1]);
                        if (currentMission.State == "inProgress")
                        {
                            missions.Add(currentMission);
                        }
                    }
                    
                    Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    soldiers.Add(commando);
                }
                else if (soldierRank == typeof(Spy).Name)
                {
                    int codeNum = int.Parse(inputArgs[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNum);
                    soldiers.Add(spy);
                }
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
