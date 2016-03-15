using GDIDrawer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MuhammadTahaSheikhCMPE2300Ica5
{
    public partial class Form1 : Form
    {
        List<Ball> listOfBalls = new List<Ball>();
        public int discard = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            listOfBalls.Clear();
            Ball.Loading = true;
            Ball.Loading = false;
        }

        public void RegenerateSortedList()
        {
            Ball.Loading = true;
            foreach (Ball ball in listOfBalls)
            {
                ball.AddBall();
                Thread.Sleep(5);
                Ball.Loading = false;
            }
        }
        private void rb_Radius_Click(object sender, EventArgs e)
        {
            pb_update.Value = 0;
            if (rb_Radius.Checked == true)
                Ball.enumSort = Ball.ESortType.eRadius;
            else if (rb_distance.Checked == true)
                Ball.enumSort = Ball.ESortType.eDistance;
            else if (rb_Color.Checked == true)
                Ball.enumSort = Ball.ESortType.eColor;
            listOfBalls.Sort();
            RegenerateSortedList();
        }
        private void btn_addballs_Click_1(object sender, EventArgs e)
        {
            Ball.Loading = true;
            pb_update.Value = 0;
            bool collision = false;
            Ball temp = null;
            int counter = 0;
            while (counter < 25 && pb_update.Value != 1000)
            {
                pb_update.Value++;
                discard++;
                temp = new Ball(tb_radius.Value);
                collision = false;
                foreach (Ball ball in listOfBalls)
                {
                    if (temp.Equals(ball))
                    {
                        collision = true;
                    }
                }

                if (!collision)
                {
                    listOfBalls.Add(temp);

                    counter++;
                }
            }
            foreach (Ball ball in listOfBalls)
            {
                ball.AddBall();
            }
            Ball.Loading = false;
            Text = "Loaded " + (listOfBalls.Count).ToString() + " distinct balls with " + discard.ToString() + " discards";
        }
        private void tb_radius_Scroll_1(object sender, EventArgs e)
        {
            lbl_radius.Text = "Size = " + tb_radius.Value.ToString();
        }
    }
}
