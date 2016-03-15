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
    public class SpinnerBall : CShape, IAnimate
    {
        double animationAngle;
        double deltaAngle;
        public SpinnerBall(Point p) : base(p)
        {
            _pLocation = p;
            deltaAngle = _rnd.NextDouble() * 0.2;
        }
        public void Animate()
        {
            animationAngle += deltaAngle;
        }

        protected override void VirtualRender()
        {
            if (_pLocation.X > _iRadius && _pLocation.Y > _iRadius && _pLocation.Y < Canvas.ScaledHeight - _iRadius && 
                _pLocation.X < Canvas.ScaledWidth - _iRadius)
            {
                Canvas.AddCenteredEllipse(_pLocation.X, _pLocation.Y, _iRadius * 2, _iRadius * 2, _color, 2, Color.Green);                
                Canvas.AddLine(_pLocation, _iRadius, animationAngle, Color.Black, 2);                              
            }
        }
    }
}
