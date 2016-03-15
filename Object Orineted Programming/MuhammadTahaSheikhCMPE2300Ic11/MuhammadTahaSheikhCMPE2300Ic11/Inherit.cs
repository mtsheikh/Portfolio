using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCMPE2300Ic11
{
    class Rect : Random
    {
        private int _max;
        public Rect(int max)
        {
            _max = max;
        }

        public Rectangle NextDrawerRect(CDrawer box)
        {
            Rectangle rect = new Rectangle(Next(box.ScaledWidth),
                                           Next(box.ScaledHeight),
                                           Next(10, _max),
                                           Next(10, _max));
            return rect;
        }
    }

    class newRect : CDrawer //Add a new class derived from the GDIDrawer.CDrawer class
    {
        Rect _rand = null; //  add a member of your derived Random class, but initialize to null       
        public newRect() : base(800, 400) // initialize the base CDrawer to show 
                                          // with a width of 800 and height of 400
        {
            _rand = new Rect(ScaledWidth / 5); // initialize your derived Random class to 1/5 of the current scaled width ( 10% will be the biggest size )
            base.BBColour = Color.White;  // set the background to White
            // Utilizing your derived Random class, create 100 Rectangles ( **But how will you pass the CDrawer instance
            // that you are … “this” is the issue ), then draw these rectangles with random KNOWN colors.
            for (int i = 0; i < 100; i++)
            {
                Rectangle Temp = _rand.NextDrawerRect(this);
                base.AddRectangle(Temp.X, Temp.Y, Temp.Width, Temp.Height, RandColor.GetKnownColor());
            }
        }
    }

    class newImage : CDrawer
    {
        Bitmap bm = new Bitmap(Properties.Resources._01_2012_tesla_model_s_fd_1347336745);
        public newImage() : base(Properties.Resources._01_2012_tesla_model_s_fd_1347336745.Width,
            Properties.Resources._01_2012_tesla_model_s_fd_1347336745.Height)
        {
            for (int x = 0; x < bm.Width; ++x)
                for (int y = 0; y < bm.Height; ++y)
                {
                    Color pixel = bm.GetPixel(x, y);
                    int average = pixel.G / 3 + pixel.R / 3 + pixel.B / 3;                    
                    pixel = Color.FromArgb(average, average, average);                    
                    base.SetBBScaledPixel(x, y, pixel);
                }
        }

    }

}
