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


namespace MuhammadTahaSheikhCMPE2300ICA003
{
    public partial class Form1 : Form
    {
        List<Ball> listBall = new List<Ball>();
        Thread Thready = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thready = new Thread(new ThreadStart(DoWork));
            Thready.Start();
            this.KeyPreview = true;
        }

        private void tb_radius_Scroll(object sender, EventArgs e)
        {
            Text = "Size = : " + tb_radius.Value.ToString();
            if (listBall.Count > 0)
            {
                Ball.Radius = tb_radius.Value;
            }
        }

        public void DoWork()
        {
            while (true)
            {
                Ball.Loading = true;
                foreach (Ball ball in listBall)
                {
                    ball.MoveBall();
                    ball.ShowBall();
                }
                Ball.Loading = false;
                Thread.Sleep(25);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                listBall.Clear();                
            }
            if (e.KeyCode == Keys.Add)
            {
                for (int i = 0; i < 5; i++)
                {
                    listBall.Add(new Ball());
                }
            }
        }
    }
}

