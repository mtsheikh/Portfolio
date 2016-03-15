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

namespace MuhammadTahaSheikhCMPE2300Assignment02
{
    public partial class Form1 : Form
    {
        public CDrawer box = new CDrawer();
        List<Ball> listBall = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            box.ContinuousUpdate = false;
        }

        private void Form1_Load(object sender, EventArgs e){}

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point pCoord;
            box.Clear();
            if (box.GetLastMouseLeftClick(out pCoord))
            {
                Ball ball = new Ball(pCoord);
                if (pCoord.X > 40 && pCoord.Y > 40 && pCoord.Y < box.m_ciHeight - 40 && pCoord.X < box.m_ciWidth - 40) 
                {
                    listBall.Add(ball);
                    Text = ball.ToString();
                }
            }
            if (box.GetLastMouseRightClick(out pCoord))
            {
                listBall.Clear();
            }
            for (int i = 0; i < listBall.Count; i++)
            {
                listBall[i].ShowBall(box);
                listBall[i].MoveBall(box);
            }
            box.Render();
        }

        private void tb_X_Scroll(object sender, EventArgs e)
        {
            lbl_X.Text = ("X: " + tb_X.Value).ToString();
            if (listBall.Count > 0)
            {
                if (chk_All.Checked)
                {
                    foreach (Ball ball in listBall)
                    {
                        ball.Xvelocity = tb_X.Value;
                    }
                }
                else
                {
                    listBall.Last().Xvelocity = tb_X.Value;
                }
            }
        }

        private void tb_Y_Scroll(object sender, EventArgs e)
        {
            lbl_Y.Text = ("Y: " + tb_Y.Value).ToString();
            if (listBall.Count > 0)
            {
                if (chk_All.Checked)
                {
                    foreach (Ball ball in listBall)
                    {
                        ball.YVelocity = tb_Y.Value;
                    }
                }
                else
                {
                    listBall.Last().YVelocity = tb_Y.Value;
                }
            }
        }

        private void tb_Opacity_Scroll(object sender, EventArgs e)
        {
            lbl_Opacity.Text = ("Opacity: " + tb_Opacity.Value).ToString();
            if (listBall.Count > 0)
            {
                if (chk_All.Checked)
                {
                    foreach (Ball ball in listBall)
                    {
                        ball.Opacity = tb_Opacity.Value;
                    }
                }
                else
                {
                    listBall.Last().Opacity = tb_Opacity.Value;
                }
            }
        }

        private void lbl_Opacity_Click(object sender, EventArgs e)
        {

        }
    }
}
