using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
using MuhammadTahaSheikhDrawers;

namespace MuhammadTahaSheikhCMPE2300IC14
{
    public class MovingBall : CShape, IMoveable
    {
        int Xvelocity;
        int Yvelocity;
        public MovingBall(Point p) : base(p)
        {
            Yvelocity = _rnd.Next(-8, 9);
            Xvelocity = _rnd.Next(-8, 9);
        }
        public void Move()
        {
            if ((_pLocation.X - _iRadius) < 0 ) // Left                 
            {
                Xvelocity *= -1;
                this._pLocation.X = _iRadius;
            }
            else if ((_pLocation.X + _iRadius) > CShape.Canvas.m_ciWidth) // Right
            {
                Xvelocity *= -1;
                this._pLocation.X = CShape.Canvas.m_ciWidth - _iRadius;
            }

            if ((_pLocation.Y - _iRadius) < 0 ) // Top                
            {
                Yvelocity *= -1;
                this._pLocation.Y = _iRadius;
            }
            else if ((_pLocation.Y + _iRadius) > CShape.Canvas.m_ciHeight) // Bottom
            {
                Yvelocity *= -1;
                this._pLocation.Y = CShape.Canvas.m_ciHeight - _iRadius;
            }
            _pLocation.X += Xvelocity;
            _pLocation.Y += Yvelocity;
        }

        protected override void VirtualRender()
        {
            Canvas.AddCenteredEllipse(_pLocation.X, _pLocation.Y, _iRadius * 2, _iRadius * 2, _color, 2, Color.Green);          
        }
    }
}
