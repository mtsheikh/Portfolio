using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace MuhammadTahaSheikhCMPE2300ICA003
{
    class Ball
    {
        static Random Rand = new Random();
        static CDrawer box = null;
        static int _radius;
        Color ballColor;
        int xVelocity;
        int yVelocity;
        int _iAlive;
        Point location;

        static public int Radius
        {
            set { _radius = Math.Abs(value); }
        }

        static Ball()
        {
            box = new CDrawer(Rand.Next(600, 901), Rand.Next(500, 801));
            Radius = Rand.Next(10, 81);
            box.ContinuousUpdate = false;
        }

        public Ball()
        {
            ballColor = RandColor.GetColor();
            xVelocity = Rand.Next(-10, 11);
            yVelocity = Rand.Next(-10, 11);
            location.X = Rand.Next(_radius, box.m_ciWidth - _radius);
            location.Y = Rand.Next(_radius, box.m_ciHeight - _radius);
        }

        public void MoveBall()
        {
            if (location.X - _radius + xVelocity < 0 || location.X + _radius + xVelocity > box.m_ciWidth)
            {
                xVelocity *= -1;
            }

            if (location.Y - _radius + yVelocity < 0 || location.Y + _radius + yVelocity > box.m_ciHeight)
            {
                yVelocity *= -1;
            }

            location.X += xVelocity;
            location.Y += yVelocity;

            if (_iAlive < 1)  // Reincarnation
            {
                location.X = Rand.Next(_radius, box.m_ciWidth - _radius);
                location.Y = Rand.Next(_radius, box.m_ciHeight - _radius);
                _iAlive = Rand.Next(50, 128);
            }
            _iAlive -= 1;
        }

        public void ShowBall()
        {
            box.AddCenteredEllipse(location.X, location.Y, 2 * _radius, 2 * _radius, Color.FromArgb(_iAlive, ballColor));
        }

        static public bool Loading
        {
            set
            {
                if (value == true)
                {
                    box.Clear();
                }
                else
                {
                    box.Render();
                }
            }
        }
    }
}
