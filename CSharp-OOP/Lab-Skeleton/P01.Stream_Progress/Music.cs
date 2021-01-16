using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Music : BaseClass
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent) 
            : base(bytesSent, length)
        {
            this.artist = artist;
            this.album = album;
        }
    }
}
