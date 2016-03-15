using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCMPE2300Ica5
{
    class Ball : IComparable
    {
        public enum ESortType { eRadius, eDistance, eColor };
        private static CDrawer _box = null;
        private static Random _gen = new Random();
        int _radius;
        Color _color;
        Point _center;

        public static ESortType enumSort { get; set; }
        public int Radius
        {
            set { _radius = Math.Abs(value); }
        }

        static Ball()
        {
            _box = new CDrawer();
            _box.ContinuousUpdate = false;
            enumSort = ESortType.eRadius;
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

        public int CompareTo(object obj)
        {
            if (!(obj is Ball))
                throw new ArgumentException("Not a valid Ball, or is null");

            Ball temp = obj as Ball;
            int value = 0;

            if (enumSort == ESortType.eRadius) // if the enum sort is Radius
            {
                value = _radius - temp._radius;                
            }

            if (enumSort == ESortType.eColor)
            {
                value = _color.ToArgb() - temp._color.ToArgb();
            }

            if (enumSort == ESortType.eDistance)
            {                
                double ballOne = Math.Sqrt((Math.Pow(_center.X, 2) + Math.Pow(_center.Y, 2)));
                double ballTwo = Math.Sqrt((Math.Pow(temp._center.X, 2) + Math.Pow(temp._center.Y, 2)));
                value = (int)ballOne - (int)ballTwo;
            }
            return value;
        }
    }
}

