﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }

    }
}
