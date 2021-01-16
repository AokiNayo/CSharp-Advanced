using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }
        public int Count
        { 
            get
            {
                return data.Count;
            }
        }

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public void Remove(string name)
        {
            data.Remove(data.FirstOrDefault(x => x.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            return data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }
        public Hero GetHeroWithHighestAbility()
        {
            return data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            return data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
