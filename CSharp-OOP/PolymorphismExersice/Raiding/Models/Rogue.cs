using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;
        public Rogue(string name)
            : base(name)
        {
            this.Power = ROGUE_POWER;
        }
        public override string CastAbitity()
        {
            return $"{GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
