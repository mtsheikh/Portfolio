using System;
using System.Drawing;
using GDIDrawer;


namespace MuhammadTahaSheikhCMPE2300Assignment01
{
    public class TrekLight
    {
        Color _lightColor;
        byte _byThreshold;
        byte _byTick;
        int _border;

        public Color LightColor
        {
            set { _lightColor = value; }
            get { return _lightColor; }
        }

        public byte ByThreshold
        {
            set { _byThreshold = value; }
            get { return _byThreshold; }
        }

        public byte ByTick
        {
            set { _byTick = value; }
            get { return _byTick; }
        }
        // Custom Constructor
        public TrekLight(Color lightColor, byte bythreshold, byte bytick, int border)
        {
            _lightColor = lightColor;
            _byThreshold = bythreshold;
            _byTick = bythreshold;
            _border = border;
        }
        // Default Constructor
        public TrekLight() : this(RandColor.GetColor(), 64, 64, 5) { }
        public void Tick()
        {
            _byTick += 3;
        }

        public void Render(CDrawer box, int num)
        {
            int column = num / box.ScaledWidth ;
            int row = num % box.ScaledWidth;
            if (_byTick > _byThreshold)
            {
                box.AddRectangle(row, column, 1, 1, _lightColor, _border, Color.Black);
            }
        }

    }
}
