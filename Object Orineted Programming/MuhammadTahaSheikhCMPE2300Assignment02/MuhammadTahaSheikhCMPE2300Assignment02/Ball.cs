using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;


namespace MuhammadTahaSheikhCMPE2300Assignment02
{
    class Ball
    {
        static Random Rand = new Random();
        public int radius = 40;
        Color _ballColor;
        int _Xvelocity;
        int _Yvelocity;
        public Point _center;

        private Point Location
        {
            get { return _center; }
        }

        public int Xvelocity
        {
            set { _Xvelocity = value; }
        }

        public Color BallColor
        {
            get { return _ballColor; } 
            set { _ballColor = value; }
        }

        public int YVelocity
        {
            set
            {
                if (value > 10) { value = 10; }
                else if (value < -10) { value = -10; }
                _Yvelocity = value;
            }
        }

        public int Opacity // Automatic public Method
        {
            private get;
            set;        
        }

        public override string ToString()
        {
            return string.Format("[ X = {0}, Y = {1}] - Vel : {2}, {3}, Opacity: {4}", _center.X,_center.Y,_Xvelocity,
                _Yvelocity,Opacity);
        }


        public Ball(Point p)
        {
            _ballColor = (RandColor.GetColor());
            Xvelocity = Rand.Next(-10, 11);
            YVelocity = Rand.Next(-10, 11);
            Opacity = 128;
            _center = p;
        }

        public void MoveBall(CDrawer box)
        {
            if (_center.X - radius + _Xvelocity < 0 || _center.X + radius + _Xvelocity > box.m_ciWidth)
            {
                _Xvelocity *= -1;
            }

            if (_center.Y - radius + _Yvelocity < 0 || _center.Y + radius + _Yvelocity> box.m_ciHeight)
            {
                _Yvelocity *= -1;
            }

            _center.X += _Xvelocity;
            _center.Y += _Yvelocity;
        }

    public void ShowBall(CDrawer box)
        {
            box.AddCenteredEllipse(Location.X, Location.Y, 2*radius, 2*radius, Color.FromArgb(Opacity,_ballColor));
        }
    }
}
