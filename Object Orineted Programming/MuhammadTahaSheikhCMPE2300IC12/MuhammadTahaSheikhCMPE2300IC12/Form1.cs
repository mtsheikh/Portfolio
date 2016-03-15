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

namespace MuhammadTahaSheikhCMPE2300IC12
{
    public partial class Form1 : Form
    {
        public int counter = 0;
        public int redCounter = 0;
        newImage bgBox = new newImage(Properties.Resources._01_2012_tesla_model_s_fd_1347336745);
        newRect rBox = new newRect();
        List<BouncingBall> blueBalls = new List<BouncingBall>();
        List<BouncingBall> redBalls = new List<BouncingBall>();
        List<BouncingBall> greenBalls = new List<BouncingBall>();
        public Point pCoord;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bgBox.ContinuousUpdate = false;
            rBox.ContinuousUpdate = false;
            while (bgBox.GetLastMouseLeftClick(out pCoord)) ;
            while (bgBox.GetLastMouseRightClick(out pCoord)) ;
            timr_timer.Start();

        }

        private void timr_timer_Tick(object sender, EventArgs e)
        {
            bgBox.Clear();
            rBox.Clear();
            if (bgBox.GetLastMouseLeftClick(out pCoord))
            {
                BouncingBall greenBall = new BouncingBall(pCoord, Color.Green);
                if ((!(pCoord.X > bgBox.ScaledWidth - greenBall._radius || pCoord.X < greenBall._radius)) &&
                   (!(pCoord.Y > bgBox.ScaledHeight - greenBall._radius || pCoord.Y < greenBall._radius)))
                {
                    if (!(greenBalls.Contains(greenBall)))
                    {
                        greenBalls.Add(greenBall);
                    }
                }

            }
            if (bgBox.GetLastMouseRightClick(out pCoord))
            {
                BouncingBall blueBall = new BouncingBall(pCoord, Color.Blue);
                if ((!(pCoord.X > bgBox.ScaledWidth - blueBall._radius || pCoord.X < blueBall._radius)) &&
                 (!(pCoord.Y > bgBox.ScaledHeight - blueBall._radius || pCoord.Y < blueBall._radius)))
                {
                    if (blueBalls.IndexOf(blueBall) == -1)
                    {
                        blueBalls.Insert(0, blueBall);
                    }
                }
            }

            for (int i = 0; i < greenBalls.Count; i++)
            {
                greenBalls[i].MoveBall(bgBox);
            }

            for (int i = 0; i < blueBalls.Count; i++)
            {
                blueBalls[i].MoveBall(bgBox);
            }

            for (int i = 0; i < redBalls.Count; i++)
            {
                redBalls[i].MoveBall(rBox);
            }

            List<BouncingBall> collidedList = new List<BouncingBall>();
            collidedList = greenBalls.Intersect(blueBalls).ToList();

            foreach (BouncingBall collidedBall in collidedList)
            {
                greenBalls.Remove(collidedBall);
                blueBalls.Remove(collidedBall);
                redBalls.Add(new BouncingBall(pCoord, Color.Red));
            }

            collidedList = new List<BouncingBall>(redBalls.Distinct());

            for (int i = 0; i < greenBalls.Count; i++)
            {
                greenBalls[i].ShowBall(bgBox, i);
            }

            for (int i = 0; i < blueBalls.Count; i++)
            {
                blueBalls[i].ShowBall(bgBox, i);
            }

            for (int i = 0; i < redBalls.Count; i++)
            {
                redBalls[i].ShowBall(rBox, i);
            }

            bgBox.AddText("Blue: " + blueBalls.Count + " Green: " + greenBalls.Count, 24f, Color.FromArgb(125, Color.Gray));
            rBox.AddText("Collided: " + redBalls.Count, 24f, Color.FromArgb(125, Color.Gray));
            bgBox.Render();
            rBox.Render();
        }
    }
}

