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
    public abstract class CShape
    {
        public static MuhammadTahaSheikhDrawers.newImage Canvas { get; set; }
        protected static Random _rnd = new Random();
        protected Point _pLocation;
        protected Color _color = RandColor.GetColor();
        protected int _iRadius;
        static CShape()
        {
            _rnd = new Random(0);
        }
        public CShape(Point p)
        {
            _pLocation = p;
            _iRadius = _rnd.Next(25, 51);
        }
        public void Render()
        {
            VirtualRender();
            Canvas.AddText("{" + _pLocation.X + "," + _pLocation.Y + "}", 9f,
                 _pLocation.X - _iRadius, _pLocation.Y - _iRadius, 2 * _iRadius, 2 * _iRadius, Color.Black);
        }
        protected abstract void VirtualRender();
    }

    interface IMoveable
    {
        void Move();
    }

    interface IAnimate
    {
        void Animate();
    }
}
