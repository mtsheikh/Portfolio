using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace MuhammadTahaSheikhCapstoneSimulation
{
    public class AccessPoint
    {
        public int _radius;       
       

        public Point _origin;
        public List<Point> endPoints = null;
        Point _distance = new Point(400, 300);

        public AccessPoint(Point pCoord, int radius)
        {                
            _origin = pCoord;
            _radius = radius;
            endPoints = new List<Point>();
        }
        // This method creates an access point and stores the end points from it into a list of endpoints 
        public void Render(CDrawer _box)
        {
            Color c = Color.FromArgb(255, (int)((_radius / (double)400) * 255),255, 0);
            _box.AddCenteredEllipse(_origin.X, _origin.Y, _radius * 2, _radius * 2, Color.Transparent,1,Color.Red);

            //for (double i = 0; i < 360; i++)
            //{
            //   // _box.AddLine(_origin, _radius,i, Color.Red);
            //    //double x = _origin.X + (_distance.X * Math.Cos(i * (Math.PI / 180.0)));
            //    //double y = _origin.Y + (_distance.Y * Math.Sin(i * (Math.PI / 180.0)));
            //    // this is the algorithim for figuring out the endpoints of all circles
            //    double x = _origin.X + (_radius * Math.Cos(i * (Math.PI / 180.0)));
            //    double y = _origin.Y + (_radius * Math.Sin(i * (Math.PI / 180.0)));
            //    //endPoints.Add(new Point((int)x,(int) y));                
            //}
            

            //foreach (var item in endPoints)
            //{
            //    _box.SetBBPixel(item.X, item.Y, Color.White);
            //}

        }
        
    }
}
