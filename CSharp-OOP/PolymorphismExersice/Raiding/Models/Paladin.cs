using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PALADIN_POWER = 100;

        public Paladin(string name)
            : base(name)
        {
            this.Power = PALADIN_POWER;
        }

        public override string CastAbitity()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
