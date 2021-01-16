using System;
using Raiding.Common;
using Raiding.Models;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public HeroFactory()
        {

        }

        public BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_HERO_MSG);
            }

            return hero;

        }
    }
}
