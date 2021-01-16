using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int FireRate = 1;
        public Pistol(string name, int bulletCount)
            : base(name, bulletCount)
        {
        }

        //protected override int FireRate => 1;
        public override int Fire()
        {
            if (this.BulletsCount < FireRate)
                return 0;
            else
            {
                this.BulletsCount -= FireRate;
            }

            return FireRate;

        }
    }
}
