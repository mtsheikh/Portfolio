using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace MuhammadTahaSheikhCapstoneSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CDrawer _box = new CDrawer(800, 600, false);// bContinuousUpdate = false);

        // This is for inputting the floor plan into the GDI Drawer
        Bitmap bm = new Bitmap(Properties.Resources.Create_Simple_Floor_Plans);

        public Point Pcoord = new Point();
        Random rand = new Random();
        List<AccessPoint> accessPoints = new List<AccessPoint>();
        public int radius = 0;
        public List<Point> PossibleLoc = new List<Point>();
        public Point found = new Point();

        private void Form1_Load(object sender, EventArgs e)
        {
            // putting picture in the GDI Drawer
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    Color pixel = bm.GetPixel(x, y);
                    _box.SetBBScaledPixel(x, y, pixel);
                }
            }

            accessPoints.Add(new AccessPoint(new Point(100, 100), 300));
            _box.SetBBPixel(100, 100, Color.Red);

            accessPoints.Add(new AccessPoint(new Point(100, 500), 300));
            _box.SetBBPixel(100, 500, Color.Red);

            accessPoints.Add(new AccessPoint(new Point(400, 300), 300));
            _box.SetBBPixel(400, 300, Color.Red);

            accessPoints.Add(new AccessPoint(new Point(700, 100), 300));
            _box.SetBBPixel(700, 100, Color.Red);

            accessPoints.Add(new AccessPoint(new Point(700, 500), 300));
            _box.SetBBPixel(700, 500, Color.Red);




            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //_box.Clear();
            //if (_box.GetLastMouseLeftClick(out Pcoord))
            //{
            //    accessPoints.Add(new AccessPoint(Pcoord, radius));
            //    _box.SetBBPixel(Pcoord.X, Pcoord.Y, Color.Blue);
            //}

 

            //foreach (AccessPoint accessPoint in accessPoints)
            //{
            //    accessPoint._radius = radius;
            //    accessPoint.Render(_box);

            //}

            // _box.Render();

            // you cannot use Pccord this is where you will find the three intersections point
            //if (_box.GetLastMousePosition(out Pcoord) && accessPoints.Count > 0)
            //{

            _box.Clear();
            bool bRes = _box.GetLastMousePosition(out Pcoord);
            foreach (AccessPoint accessPoint in accessPoints)
            {
                accessPoint._radius = (int)Math.Sqrt((Math.Pow((Pcoord.X - accessPoint._origin.X), 2) +
                (Math.Pow((Pcoord.Y - accessPoint._origin.Y), 2))));
                if (accessPoint._radius > 400)
                {
                    accessPoint._radius = 10;
                }
                accessPoint.Render(_box);

                                
            }
            _box.Render();
            //}
            //if (accessPoints.Count > 1)
            //{
            //    foreach (Point endPointAp1 in accessPoints[0].endPoints)
            //    {
            //        foreach (Point endPointAp2 in accessPoints[1].endPoints)
            //        {
            //            if (endPointAp1.Equals(endPointAp2))
            //            {
            //                if (!(listBox1.Items.Contains(endPointAp1)))
            //                {
            //                    listBox1.Items.Add(endPointAp1);
            //                    PossibleLoc.Add(endPointAp1);
            //                }
            //            }
            //        }
            //    }            
            //}
            //if (accessPoints.Count > 3)
            //{
            //    for (int i = 1; i < accessPoints.Count; i++)
            //    {


            //        foreach (Point endPointAp3 in accessPoints[i].endPoints)
            //        {
            //            foreach (Point pointer in PossibleLoc)
            //            {
            //                if (endPointAp3.Equals(pointer))
            //                {
            //                    found = endPointAp3;

            //                }
            //            }
            //        }
            //    }
            //}

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            radius = trackBar1.Value;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bRes = _box.GetLastMouseLeftClick(out Pcoord);
            listBox1.Items.Add(Pcoord);
            listBox1.Items.Add(accessPoints[0]._radius.ToString() + " The first Access Point: " + accessPoints[0]._origin.ToString());
            listBox1.Items.Add(accessPoints[1]._radius.ToString() + " The second Access Point: " + accessPoints[1]._origin.ToString());
            listBox1.Items.Add(accessPoints[2]._radius.ToString() + " The third Access Point: " + accessPoints[2]._origin.ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
