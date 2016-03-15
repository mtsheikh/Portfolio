using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace MuhammadTahaSheikhCMPE2300ICA4
{
    class Ball
    {
        private static CDrawer _box = null;
        private static Random _gen = new Random();
        int _radius;
        Color _color;
        Point _center;

        public int Radius
        {
            set { _radius = Math.Abs(value); }
        }

        static Ball()
        {
            _box = new CDrawer();
            _box.ContinuousUpdate = false;
        }

        public Ball(int radius)
        {
            Radius = radius;
            _color = RandColor.GetColor();
            _center.X = _gen.Next(_radius, _box.ScaledWidth - _radius);
            _center.Y = _gen.Next(_radius, _box.ScaledHeight - _radius);
        }

        public void AddBall()
        {
            _box.AddCenteredEllipse(_center.X, _center.Y, _radius * 2, _radius * 2, _color);
        }

        public static bool Loading
        {
            set
            {
                if (value)
                    _box.Clear();
                else
                    _box.Render();
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ball))
                return false;
            Ball temp = obj as Ball;

            return Math.Sqrt((Math.Pow(temp._center.X - _center.X, 2) + Math.Pow(temp._center.Y - _center.Y, 2))) <= _radius + temp._radius;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
