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

namespace MuhammadTahaSheikhCMPE2300Assignment01
{

    public partial class Form1 : Form
    {
        List<TrekLight> listTrekLights = new List<TrekLight>();
        public CDrawer box = new CDrawer();
        public Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            box.Scale = 50;
            timer1.Start();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(KeyPressed);

        }
        // this is the same thing as CKI but 
        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString().ToUpper())
            {
                case "D":
                    listTrekLights.Add(new TrekLight());
                    break;
                case "F":
                    listTrekLights.Add(new TrekLight(Color.Red, 127, 127, 5));
                    break;
                case "G":
                    listTrekLights.Add(new TrekLight(RandColor.GetColor(), (byte)rand.Next(40, 201), (byte)rand.Next(40, 201), 4));
                    break;
                case "C":
                    if (listTrekLights.Count > 0)
                        listTrekLights.Remove(listTrekLights[listTrekLights.Count - 1]);
                    break;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            box.Clear();
            for (int i = 0; i < listTrekLights.Count; i++)
            {
                listTrekLights[i].Tick();
                listTrekLights[i].Render(box, i);
            }
        }
    }

}
