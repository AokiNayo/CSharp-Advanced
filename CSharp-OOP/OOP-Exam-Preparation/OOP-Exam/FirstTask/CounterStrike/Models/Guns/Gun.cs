using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletCount)
        {
            this.Name = name;
            this.BulletsCount = bulletCount;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => this.bulletsCount;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this.bulletsCount = value;
            }
        }

        public abstract int Fire();
        //protected abstract int FireRate { get; }

        //public int Fire()
        //{
        //    if (FireRate > this.BulletsCount)
        //    {
        //        return 0;
        //    }

        //    this.BulletsCount -= FireRate;

        //    return FireRate;
        //}
    }
}
