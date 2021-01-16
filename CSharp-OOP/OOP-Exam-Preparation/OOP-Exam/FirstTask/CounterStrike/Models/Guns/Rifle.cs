using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int FireRate = 10;
        public Rifle(string name, int bulletCount)
            : base(name, bulletCount)
        {
        }

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
