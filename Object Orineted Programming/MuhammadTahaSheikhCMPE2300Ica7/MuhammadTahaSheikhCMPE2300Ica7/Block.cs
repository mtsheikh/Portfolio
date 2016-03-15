using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCMPE2300Ica7
{
    class Block : IComparable
    {
        public static CDrawer Canvas { get; private set; }
        public static int Height { get; private set; }

        private Color _color;
        private static Random _gen = new Random(1);
        public int Width { get; private set; }
        public bool HighLight { get; set; }

        static Block()
        {
            Height = 20;
            Canvas = new CDrawer();
            Canvas.BBColour = Color.White;
            Canvas.ContinuousUpdate = false;
        }

        public Block()
        {
            Width = _gen.Next(1, 20) * 10;
            HighLight = false;
            _color = Color.FromArgb(_gen.Next(2, 8) * 32, _gen.Next(2, 8) * 16, _gen.Next(2, 8) * 16);//Whatzit makin' ?
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Block))
                return false;

            Block Temp = obj as Block;
            return Temp.Width.Equals(Width) && Temp._color.Equals(_color);
        }

        public void ShowBlock(Point point)
        {
            if (HighLight)
                Canvas.AddRectangle(point.X, point.Y, Width, Height, _color, 2, Color.Yellow);
            else
                Canvas.AddRectangle(point.X, point.Y, Width, Height, _color, 1, Color.Black);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Block))
                throw new ArgumentException("You have passed in an incorrect type!");

            Block Temp = obj as Block;

            return _color.ToArgb() - Temp._color.ToArgb();
        }

        public static int WidthComparison(object left, object right)
        {
            if (!(left is Block))
                throw new ArgumentException("left is not the appropiate type");

            if (!(right is Block))
                throw new ArgumentException("right is not the appropiate type");

            Block leftTemp = left as Block;
            Block rightTemp = right as Block;

            return leftTemp.Width.CompareTo(rightTemp.Width); //left one is smaller than -1
        }

        public static int WidththanColorComparison(Block left, Block right)
        {
            if (left.Width.CompareTo(right.Width) == 0)
                return left._color.ToArgb() - right._color.ToArgb();
            else 
                return left.Width.CompareTo(right.Width);            
        }

        public static bool RemoveBright(Block obj)
        {
            if (obj == null) return false;
            return obj._color.GetBrightness() > 0.5;
        }
    }
}

