using Raiding.Core.Contracts;
using Raiding.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly HeroFactory heroFactory;

        public Engine()
        {
            heroFactory = new HeroFactory();
        }
        public void Run()
        {
            List<BaseHero> raid = CreateRaidGroup();

            int bossHealth = int.Parse(Console.ReadLine());
            var totalDmg = 0;

            foreach (var hero in raid)
            {
                Console.WriteLine(hero.CastAbitity());
                totalDmg += hero.Power;
            }

            Console.WriteLine(totalDmg >= bossHealth ? "Victory!" : "Defeat...");
        }

        public List<BaseHero> CreateRaidGroup()
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raid = new List<BaseHero>();
            BaseHero currentHero = null;

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroClass = Console.ReadLine();

                try
                {
                    currentHero = this.heroFactory.CreateHero(heroClass, name);

                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                    i--;
                    continue;
                }
                raid.Add(currentHero);
            }
            return raid;
        }
    }
}
