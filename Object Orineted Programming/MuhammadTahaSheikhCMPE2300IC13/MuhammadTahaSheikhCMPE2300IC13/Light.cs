using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuhammadTahaSheikhDrawers;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCMPE2300IC13
{
    public class Light 
    {
        protected Point _center;
        protected Color _color;
        public bool KillMe { protected set; get; }

        public Light(Point center) 
        {
            _center = center;
            _color = RandColor.GetKnownColor();
            KillMe = false;
        }

        public virtual void Animate() { }

        public virtual void Draw(CDrawer box)
        {
            box.AddEllipse(_center.X, _center.Y, 4, 4, Color.Red);
        }
    }
    class FadeLight : Light
    {
        public int opacity = 255;
        public FadeLight(Point center) : base(center)
        {
            _center = center;
        }
        public override void Animate()
        {
            opacity -= 10;

            if (opacity <= 10)
                KillMe = true;
        }
        public override void Draw(CDrawer box)
        {
            box.AddEllipse(_center.X - 30, _center.Y - 30, 60, 60, Color.FromArgb(opacity, _color));
            base.Draw(box);
        }
    }

    class ShrinkLight : Light
    {
        public double radius = 40;

        public ShrinkLight(Point center) : base(center)
        {
            _center = center;
        }

        public override void Animate()
        {
            radius -= (radius * .05);

            if (radius < 2)
                KillMe = true;
        }

        public override void Draw(CDrawer box)
        {
            box.AddPolygon(_center.X - (int)radius, _center.Y - (int)radius, (int)radius, 8, 0, _color);
            base.Draw(box);
        }
    }

    class SpinLight : Light
    {
        public double rotation = 2 * Math.PI;
        public SpinLight(Point center) : base(center)
        {
            _center = center;
        }
        public override void Animate()
        {
            rotation -= (rotation * .10);

            if (rotation < 0.1)
                KillMe = true;
        }
        public override void Draw(CDrawer box)
        {
            box.AddPolygon(_center.X - 40, _center.Y - 40, 40, 3, rotation, _color);
            base.Draw(box);
        }
    }
}
