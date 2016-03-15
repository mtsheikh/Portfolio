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
using MuhammadTahaSheikhDrawers;

namespace MuhammadTahaSheikhCMPE2300IC13
{
    public partial class Form1 : Form
    {
        List<Light> Lights = new List<Light>();
        //Image bm = Properties.Resources.Koala;
        newImage img = new newImage(Properties.Resources.Koala);
        Random Rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point pCoord;
            if (img.GetLastMouseLeftClick(out pCoord))
            {
                int choice = Rand.Next(0, 3);
                if (choice == 0)
                    Lights.Add(new FadeLight(pCoord));
                else if (choice == 1)
                    Lights.Add(new ShrinkLight(pCoord));
                else
                    Lights.Add(new SpinLight(pCoord));
            }
            img.Clear();
            foreach (Light light in Lights)
            {
                light.Animate();
                light.Draw(img);
            }
            Lights.RemoveAll(obj => obj.KillMe == true);
        }
    }
}
