﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');

            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }
            DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width; ++i)
            {
                Console.Write(mid);

            }
            Console.WriteLine(end);
        }
    }
}
