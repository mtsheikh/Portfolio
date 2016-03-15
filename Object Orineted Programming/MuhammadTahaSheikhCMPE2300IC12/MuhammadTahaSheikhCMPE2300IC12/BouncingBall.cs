using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCMPE2300IC12
{
    class BouncingBall
    {
        List<Rectangle> listOfRect = new List<Rectangle>();

        static Random _rand = new Random();
        Point _center;
        int _xVelocity;
        int _yVelocity;
        public int _radius;
        public Color BallColor { get; set; }

        public BouncingBall(Point center, Color ballColor)
        {
            _center = center;
            BallColor = ballColor;
            _xVelocity = _rand.Next(-5, 6);
            _yVelocity = _rand.Next(-5, 6);
            _radius = _rand.Next(20, 51);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BouncingBall))
                return false;
            BouncingBall temp = obj as BouncingBall;

            return Math.Sqrt((Math.Pow(temp._center.X - _center.X, 2) + Math.Pow(temp._center.Y - _center.Y, 2)))
                <= _radius + temp._radius;
        }
        public override int GetHashCode()
        {
            return 1;
        }

        public void ShowBall(CDrawer box, int num)
        {
            box.AddCenteredEllipse(_center.X, _center.Y, 2 * _radius, 2 * _radius, Color.FromArgb(BallColor.ToArgb()));
            box.AddText(num.ToString(), 14f, _center.X - _radius, _center.Y - _radius, 2 * _radius, 2 * _radius,
                Color.FromArgb(255, Color.FromArgb(~BallColor.ToArgb())));
            box.Render();
        }

        public void MoveBall(CDrawer box)
        {
            if (_center.X - _radius + _xVelocity < 0 || _center.X + _radius + _xVelocity > box.m_ciWidth)
            {
                _xVelocity *= -1;
            }

            if (_center.Y - _radius + _yVelocity < 0 || _center.Y + _radius + _yVelocity > box.m_ciHeight)
            {
                _yVelocity *= -1;
            }
            _center.X += _xVelocity;
            _center.Y += _yVelocity;
        }
    }



}

