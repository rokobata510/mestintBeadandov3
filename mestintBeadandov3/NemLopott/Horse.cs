using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestintBeadandov3.NemLopott
{
    internal class Horse
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private Color color;

        public Color Color
        {
            get { return color; }
            set
            {
                if (value == Color.Red || value == Color.Blue)
                {
                    color = value;
                }

                else
                {
                    throw new Exception("Invalid color");
                }
            }
        }
        public Horse(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
        public Horse(int x, int y)
        {
            X = x;
            Y = y;
            color = Color.Black;
        }


    }
}
