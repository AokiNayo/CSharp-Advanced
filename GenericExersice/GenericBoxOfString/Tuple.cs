using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Tuple <TFirst,TSecond>
    {
        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }


        public Tuple(TFirst first, TSecond second)
        {
            this.FirstItem = first;
            this.SecondItem = second;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
