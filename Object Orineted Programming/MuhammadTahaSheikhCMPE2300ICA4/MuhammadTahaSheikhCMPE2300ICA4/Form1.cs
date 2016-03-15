using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuhammadTahaSheikhCMPE2300ICA4
{
    public partial class Form1 : Form
    {
        List<Ball> listOfBalls = new List<Ball>();
        public Form1()
        {
            InitializeComponent();
        }

        private void tb_radius_Scroll(object sender, EventArgs e)
        {
            lbl_radius.Text = "Size = " + tb_radius.Value.ToString();
        }

        private void pb_update_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_addballs_Click(object sender, EventArgs e)
        {
            Ball.Loading = true;
            pb_update.Value = 0;
            bool collision = false;
            Ball temp = null;
            int counter = 0;
            while (counter <= 25 && pb_update.Value != 1000)
            {
                pb_update.Value++;                    
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
        }
    }
}
