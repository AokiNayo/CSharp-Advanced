using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;
        public Warrior(string name) 
            : base(name)
        {
            this.Power = WARRIOR_POWER;
        }

        public override string CastAbitity()
        {
            return $"{GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
