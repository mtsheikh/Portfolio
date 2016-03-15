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
using System.Threading;
using MuhammadTahaSheikhDrawers;


namespace MuhammadTahaSheikhCMPE2300IC18
{
    public partial class Form1 : Form
    {
        private Thread Thread;
        List<Thread> Threads;
        CDrawer canvas = new CDrawer(bContinuousUpdate: false);

        public delegate void delvoidColorPoint(Color color, Point point);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Threads = new List<Thread>();

        }
        private void Wanderer(object p)
        {
            Random gen = new Random();
            Point location = (Point)p;
            Point velocity = new Point(1, 1);
            Color color = RandColor.GetColor();
            Point Temp = (Point)p;
            int n = gen.Next(10000);
            int i = 0;
            do
            {

                velocity.X = gen.Next(-1, 2);
                velocity.Y = gen.Next(-1, 2);

                if ((location.X + velocity.X < canvas.ScaledWidth && location.X + velocity.X >= 0 &&
                     location.Y + velocity.Y < canvas.ScaledHeight && location.Y + velocity.Y >= 0))
                {

                    location.X += velocity.X;
                    location.Y += velocity.Y;
                    i++;
                }

                Invoke(new delvoidColorPoint(Render), color, location);

                Thread.Sleep(1);
            } while (i < n);
        }

        public void Render(Color color, Point location)
        {
            canvas.Clear();
            canvas.SetBBScaledPixel(location.X, location.Y, color);
            canvas.Render();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            Point p;
            if (canvas.GetLastMouseLeftClick(out p))
            {

                Thread = new Thread(Wanderer);
                Thread.IsBackground = true;
                Thread.Start(p);
                Threads.Add(Thread);
            }   
        }
    }
}
