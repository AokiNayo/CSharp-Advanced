using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class BaseClass
    {
        public BaseClass(int bytesSent, int length)
        {
            BytesSent = bytesSent;
            Length = length;
        }
        public int BytesSent { get; set; }
        public int Length { get; set; }

    }
}
